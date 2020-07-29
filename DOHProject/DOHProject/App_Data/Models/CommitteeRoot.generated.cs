//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.3
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
	/// <summary>Committee Root</summary>
	[PublishedModel("committeeRoot")]
	public partial class CommitteeRoot : PublishedContentModel, IContentControls, INavigationControls
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const string ModelTypeAlias = "committeeRoot";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<CommitteeRoot, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public CommitteeRoot(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Content Grid: Enter the content for the grid
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("contentGrid")]
		public global::Newtonsoft.Json.Linq.JToken ContentGrid => global::Umbraco.Web.PublishedModels.ContentControls.GetContentGrid(this);

		///<summary>
		/// Main Image: Choose an image to show as the main image on this page
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("mainImage")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent MainImage => global::Umbraco.Web.PublishedModels.ContentControls.GetMainImage(this);

		///<summary>
		/// Title: Enter the title for this page. If you leave this blank, we will use the page name.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("title")]
		public string Title => global::Umbraco.Web.PublishedModels.ContentControls.GetTitle(this);

		///<summary>
		/// Disable Dropdown: Tick this box if you want to disable the dropdown for this item
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("disableDropdown")]
		public bool DisableDropdown => global::Umbraco.Web.PublishedModels.NavigationControls.GetDisableDropdown(this);

		///<summary>
		/// Text Only In Navigation: Tick this box if you want this item to be just text only in the navigation menu.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("textOnlyInNavigation")]
		public bool TextOnlyInNavigation => global::Umbraco.Web.PublishedModels.NavigationControls.GetTextOnlyInNavigation(this);

		///<summary>
		/// Umbraco Navi Hide: Tick this box if you want to hide it from the site.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide => global::Umbraco.Web.PublishedModels.NavigationControls.GetUmbracoNaviHide(this);
	}
}
