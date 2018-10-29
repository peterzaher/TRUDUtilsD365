﻿using System.Linq;
using System.ComponentModel.Composition;
using Dynamics.AX.Application;
using Microsoft.Dynamics.AX.Metadata.Core;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Exception = System.Exception;
using System.Windows.Forms;

namespace TRUDUtilsD365.CreateExtensionClass
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ClassItem))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Table))]
    class DesignerCreateExtensionClass : DesignerMenuBase
    {
        #region Member variables
        private const string addinName = "DesignerCreateExtensionClass";
        #endregion

        #region Properties
        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                //Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms.IForm c1;
                return "Create extension class";
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return DesignerCreateExtensionClass.addinName;
            }
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                CreateExtensionClassDialog dialog = new CreateExtensionClassDialog();
                CreateExtensionClassParms parms = new CreateExtensionClassParms();

                if (e.SelectedElement is IForm)
                {
                    var form = e.SelectedElement as IForm;
                    parms.ElementType = UtilElementType.Form;
                    parms.ElementName = form.Name;
                }
                if (e.SelectedElement is ClassItem)
                {
                    var form = e.SelectedElement as ClassItem;
                    parms.ElementType = UtilElementType.Class;
                    parms.ElementName = form.Name;
                }
                if (e.SelectedElement is Table)
                {
                    var form = e.SelectedElement as Table;
                    parms.ElementType = UtilElementType.Table;
                    parms.ElementName = form.Name;
                }
                //parms.MethodName = "find";
                dialog.setParameters(parms);
                DialogResult  formRes = dialog.ShowDialog();
                if (formRes == DialogResult.OK)
                {
                    parms.createClass();
                }
               

            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
        #endregion
    }
}