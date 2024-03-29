﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using Chai.WorkflowManagment.CoreDomain.Setting;
using Chai.WorkflowManagment.Shared;
using Chai.WorkflowManagment.CoreDomain.Inventory;
using Chai.WorkflowManagment.CoreDomain.Users;
using Chai.WorkflowManagment.Modules.Setting;
using Chai.WorkflowManagment.Modules.Admin;

namespace Chai.WorkflowManagment.Modules.Inventory.Views
{
    public class FixedAssetPresenter : Presenter<IFixedAssetView>
    {
        private InventoryController _controller;
        private SettingController _settingController;
        private AdminController _adminController;
        public FixedAssetPresenter([CreateNew] InventoryController controller, [CreateNew] SettingController settingController, [CreateNew] AdminController adminController)
        {
            _controller = controller;
            _settingController = settingController;
            _adminController = adminController;
        }

        public override void OnViewLoaded()
        {
        }
        public override void OnViewInitialized()
        {
        }
        public IList<AppUser> GetUsers()
        {
            return _adminController.GetUsers();
        }
        public IList<Store> GetStores()
        {
            return _settingController.GetStores();
        }
        public IList<Section> GetSectionsByStoreId(int storeId)
        {
            return _settingController.GetSectionBystoreId(storeId);
        }
        public IList<Shelf> GetShelvesBySectionId(int sectionId)
        {
            return _settingController.GetShelvesBySectionId(sectionId);
        }
        public IList<FixedAsset> ListFixedAssets(string item, string assetStatus)
        {
            return _controller.ListFixedAssets(item, assetStatus);
        }
        public FixedAsset GetFixedAsset(int fixedAssetId)
        {
            return _controller.GetFixedAsset(fixedAssetId);
        }
        public void SaveOrUpdateFixedAsset(FixedAsset fa)
        {
            _controller.SaveOrUpdateEntity(fa);
        }
    }
}




