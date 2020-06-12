//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.1
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Search</summary>
	[PublishedModel("search")]
	public partial class Search : PublishedContentModel, IMetaDataControls, INavigationControls, IUmbracoUrlAliasControls
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "search";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Search, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Search(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Meta Description: Enter the meta description. This is what shows up in Google etc. If left blank, will use the page name.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("metaDescription")]
		public string MetaDescription => global::Umbraco.Web.PublishedModels.MetaDataControls.GetMetaDescription(this);

		///<summary>
		/// Meta Keywords: Enter the meta keywords. This is used for Search Engine
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("metaKeywords")]
		public global::System.Collections.Generic.IEnumerable<string> MetaKeywords => global::Umbraco.Web.PublishedModels.MetaDataControls.GetMetaKeywords(this);

		///<summary>
		/// Meta Name: Enter the meta name. If left blank it will use the page name.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("metaName")]
		public string MetaName => global::Umbraco.Web.PublishedModels.MetaDataControls.GetMetaName(this);

		///<summary>
		/// Disable Dropdown: Tick this box if you want to disable the dropdown for this item
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("disableDropdown")]
		public bool DisableDropdown => global::Umbraco.Web.PublishedModels.NavigationControls.GetDisableDropdown(this);

		///<summary>
		/// Text Only In Navigation: Tick this box if you want this item to be just text only in the navigation menu.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("textOnlyInNavigation")]
		public bool TextOnlyInNavigation => global::Umbraco.Web.PublishedModels.NavigationControls.GetTextOnlyInNavigation(this);

		///<summary>
		/// Umbraco Navi Hide: Tick this box if you want to hide it from the site.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide => global::Umbraco.Web.PublishedModels.NavigationControls.GetUmbracoNaviHide(this);

		///<summary>
		/// Umbraco Url Alias: Enter an alternate url in here. Please note that the values you use must be lowercase, not use a leading slash and not use a trailing ".aspx" or trailing slash. If you are adding multiple values, they must be separated with a comma.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("umbracoUrlAlias")]
		public string UmbracoUrlAlias => global::Umbraco.Web.PublishedModels.UmbracoUrlAliasControls.GetUmbracoUrlAlias(this);
	}
}
