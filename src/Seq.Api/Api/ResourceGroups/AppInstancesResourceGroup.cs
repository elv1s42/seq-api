﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seq.Api.Model.AppInstances;

namespace Seq.Api.ResourceGroups
{
    public class AppInstancesResourceGroup : ApiResourceGroup
    {
        internal AppInstancesResourceGroup(ISeqConnection connection)
            : base("AppInstances", connection)
        {
        }

        public async Task<AppInstanceEntity> FindAsync(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await GroupGetAsync<AppInstanceEntity>("Item", new Dictionary<string, object> { { "id", id } }).ConfigureAwait(false);
        }

        public async Task<List<AppInstanceEntity>> ListAsync()
        {
            return await GroupListAsync<AppInstanceEntity>("Items").ConfigureAwait(false);
        }

        public async Task<AppInstanceEntity> TemplateAsync(string appId)
        {
            if (appId == null) throw new ArgumentNullException(nameof(appId));
            return await GroupGetAsync<AppInstanceEntity>("Template", new Dictionary<string, object> { { "appId", appId } }).ConfigureAwait(false);
        }

        public async Task<AppInstanceEntity> AddAsync(AppInstanceEntity entity, bool runOnExisting = false)
        {
            return await Client.PostAsync<AppInstanceEntity, AppInstanceEntity>(entity, "Create", entity, new Dictionary<string, object> { { "runOnExisting", runOnExisting } }).ConfigureAwait(false);
        }

        public async Task RemoveAsync(AppInstanceEntity entity)
        {
            await Client.DeleteAsync(entity, "Self", entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(AppInstanceEntity entity)
        {
            await Client.PutAsync(entity, "Self", entity).ConfigureAwait(false);
        }
    }
}