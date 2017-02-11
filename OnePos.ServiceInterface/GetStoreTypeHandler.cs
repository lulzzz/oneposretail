using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel.Server;
using OnePos.Message;
using OnePos.Message.Model;
using OnePos.Persistance;
using OnePos.Framework.ServiceModel;
using OnePos.Domain;
using System.Data;

namespace OnePos.ServiceInterface
{
    public class GetStoreTypesHandler : IRequestHandler<GetStoreTypesRequest, GetStoreTypesResponse>
    { 
        private readonly IOnePosEntities _onePosEntities;
        public GetStoreTypesHandler(IOnePosEntities onePosEntities)
        { 
            _onePosEntities = onePosEntities;
        }

        public GetStoreTypesResponse Handle(GetStoreTypesRequest request)
        { 
            var response = new GetStoreTypesResponse(); 
           response.StoreTypes = _onePosEntities.GetOnePosStoreTypes().AsEnumerable().Select(x => new StoreType()
            {
                StoreTypeId = (int)x["StoreTypeId"],
                StoreName = (string)x["Name"],
                StoreDescription = (string)x["Description"]
            }).ToList();

            return response;
        }

    }
}
