/*
				   File: type_SdtK2BSearchResult_Item
			Description: K2BSearchResult
				 Author: Nemo 🐠 for C# version 16.0.10.142546
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BSearchResult_Item : GxUserType
	{
		public SdtK2BSearchResult_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BSearchResult_Item_Searchresulttitle = "";

			gxTv_SdtK2BSearchResult_Item_Searchresultimage = "";
			gxTv_SdtK2BSearchResult_Item_Searchresultimage_gxi = "";
			gxTv_SdtK2BSearchResult_Item_Searchresultdescription = "";

			gxTv_SdtK2BSearchResult_Item_Searchresultlink = "";

		}

		public SdtK2BSearchResult_Item(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override String JsonMap(String value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (String)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("SearchResultTitle", gxTpr_Searchresulttitle, false);


			AddObjectProperty("SearchResultImage", gxTpr_Searchresultimage, false);
			AddObjectProperty("SearchResultImage_GXI", gxTpr_Searchresultimage_gxi, false);



			AddObjectProperty("SearchResultDescription", gxTpr_Searchresultdescription, false);


			AddObjectProperty("SearchResultLink", gxTpr_Searchresultlink, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SearchResultTitle")]
		[XmlElement(ElementName="SearchResultTitle")]
		public String gxTpr_Searchresulttitle
		{
			get { 
				return gxTv_SdtK2BSearchResult_Item_Searchresulttitle; 
			}
			set { 
				gxTv_SdtK2BSearchResult_Item_Searchresulttitle = value;
				SetDirty("Searchresulttitle");
			}
		}




		[SoapElement(ElementName="SearchResultImage")]
		[XmlElement(ElementName="SearchResultImage")]
		[GxUpload()]

		public String gxTpr_Searchresultimage
		{
			get { 
				return gxTv_SdtK2BSearchResult_Item_Searchresultimage; 
			}
			set { 
				gxTv_SdtK2BSearchResult_Item_Searchresultimage = value;
				SetDirty("Searchresultimage");
			}
		}


		[SoapElement(ElementName="SearchResultImage_GXI" )]
		[XmlElement(ElementName="SearchResultImage_GXI" )]
		public String gxTpr_Searchresultimage_gxi
		{
			get {
				return gxTv_SdtK2BSearchResult_Item_Searchresultimage_gxi ;
			}
			set {
				gxTv_SdtK2BSearchResult_Item_Searchresultimage_gxi = value;
				SetDirty("Searchresultimage_gxi");
			}
		}

		[SoapElement(ElementName="SearchResultDescription")]
		[XmlElement(ElementName="SearchResultDescription")]
		public String gxTpr_Searchresultdescription
		{
			get { 
				return gxTv_SdtK2BSearchResult_Item_Searchresultdescription; 
			}
			set { 
				gxTv_SdtK2BSearchResult_Item_Searchresultdescription = value;
				SetDirty("Searchresultdescription");
			}
		}




		[SoapElement(ElementName="SearchResultLink")]
		[XmlElement(ElementName="SearchResultLink")]
		public String gxTpr_Searchresultlink
		{
			get { 
				return gxTv_SdtK2BSearchResult_Item_Searchresultlink; 
			}
			set { 
				gxTv_SdtK2BSearchResult_Item_Searchresultlink = value;
				SetDirty("Searchresultlink");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BSearchResult_Item_Searchresulttitle = "";
			gxTv_SdtK2BSearchResult_Item_Searchresultimage = "";gxTv_SdtK2BSearchResult_Item_Searchresultimage_gxi = "";
			gxTv_SdtK2BSearchResult_Item_Searchresultdescription = "";
			gxTv_SdtK2BSearchResult_Item_Searchresultlink = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BSearchResult_Item_Searchresulttitle;
		 
		protected String gxTv_SdtK2BSearchResult_Item_Searchresultimage_gxi;
		protected String gxTv_SdtK2BSearchResult_Item_Searchresultimage;
		 

		protected String gxTv_SdtK2BSearchResult_Item_Searchresultdescription;
		 

		protected String gxTv_SdtK2BSearchResult_Item_Searchresultlink;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="TABLEROS_WEB")]
	public class SdtK2BSearchResult_Item_RESTInterface : GxGenericCollectionItem<SdtK2BSearchResult_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BSearchResult_Item_RESTInterface( ) : base()
		{
		}

		public SdtK2BSearchResult_Item_RESTInterface( SdtK2BSearchResult_Item psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="SearchResultTitle", Order=0)]
		public  String gxTpr_Searchresulttitle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Searchresulttitle);

			}
			set { 
				 sdt.gxTpr_Searchresulttitle = value;
			}
		}

		[DataMember(Name="SearchResultImage", Order=1)]
		[GxUpload()]
		public  String gxTpr_Searchresultimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Searchresultimage)) ? PathUtil.RelativePath( sdt.gxTpr_Searchresultimage) : StringUtil.RTrim( sdt.gxTpr_Searchresultimage_gxi));

			}
			set { 
				 sdt.gxTpr_Searchresultimage = value;
			}
		}

		[DataMember(Name="SearchResultDescription", Order=2)]
		public  String gxTpr_Searchresultdescription
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Searchresultdescription);

			}
			set { 
				 sdt.gxTpr_Searchresultdescription = value;
			}
		}

		[DataMember(Name="SearchResultLink", Order=3)]
		public  String gxTpr_Searchresultlink
		{
			get { 
				return sdt.gxTpr_Searchresultlink;

			}
			set { 
				 sdt.gxTpr_Searchresultlink = value;
			}
		}


		#endregion

		public SdtK2BSearchResult_Item sdt
		{
			get { 
				return (SdtK2BSearchResult_Item)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BSearchResult_Item() ;
			}
		}
	}
	#endregion
}