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
	// Mixin Content Type with alias "latestArticlesControls"
	/// <summary>Latest Articles Controls</summary>
	public partial interface ILatestArticlesControls : IPublishedContent
	{
		/// <summary>Latest Articles Subtitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		string LatestArticlesSubtitle { get; }

		/// <summary>Latest Articles Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		string LatestArticlesTitle { get; }
	}

	/// <summary>Latest Articles Controls</summary>
	[PublishedModel("latestArticlesControls")]
	public partial class LatestArticlesControls : PublishedContentModel, ILatestArticlesControls
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const string ModelTypeAlias = "latestArticlesControls";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<LatestArticlesControls, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public LatestArticlesControls(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Latest Articles Subtitle: Enter the subtitle for the latest articles
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("latestArticlesSubtitle")]
		public string LatestArticlesSubtitle => GetLatestArticlesSubtitle(this);

		/// <summary>Static getter for Latest Articles Subtitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static string GetLatestArticlesSubtitle(ILatestArticlesControls that) => that.Value<string>("latestArticlesSubtitle");

		///<summary>
		/// Latest Articles Title: Enter a title for the latest articles
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("latestArticlesTitle")]
		public string LatestArticlesTitle => GetLatestArticlesTitle(this);

		/// <summary>Static getter for Latest Articles Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static string GetLatestArticlesTitle(ILatestArticlesControls that) => that.Value<string>("latestArticlesTitle");
	}
}
