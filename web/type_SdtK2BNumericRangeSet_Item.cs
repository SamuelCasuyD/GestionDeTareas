/*
				   File: type_SdtK2BNumericRangeSet_Item
			Description: K2BNumericRangeSet
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
	public class SdtK2BNumericRangeSet_Item : GxUserType
	{
		public SdtK2BNumericRangeSet_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BNumericRangeSet_Item_Code = "";

			gxTv_SdtK2BNumericRangeSet_Item_Description = "";

			gxTv_SdtK2BNumericRangeSet_Item_Fromvalue = "";

			gxTv_SdtK2BNumericRangeSet_Item_Tovalue = "";

		}

		public SdtK2BNumericRangeSet_Item(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("FromValue", gxTpr_Fromvalue, false);


			AddObjectProperty("ToValue", gxTpr_Tovalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public String gxTpr_Code
		{
			get { 
				return gxTv_SdtK2BNumericRangeSet_Item_Code; 
			}
			set { 
				gxTv_SdtK2BNumericRangeSet_Item_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public String gxTpr_Description
		{
			get { 
				return gxTv_SdtK2BNumericRangeSet_Item_Description; 
			}
			set { 
				gxTv_SdtK2BNumericRangeSet_Item_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="FromValue")]
		[XmlElement(ElementName="FromValue")]
		public String gxTpr_Fromvalue
		{
			get { 
				return gxTv_SdtK2BNumericRangeSet_Item_Fromvalue; 
			}
			set { 
				gxTv_SdtK2BNumericRangeSet_Item_Fromvalue = value;
				SetDirty("Fromvalue");
			}
		}




		[SoapElement(ElementName="ToValue")]
		[XmlElement(ElementName="ToValue")]
		public String gxTpr_Tovalue
		{
			get { 
				return gxTv_SdtK2BNumericRangeSet_Item_Tovalue; 
			}
			set { 
				gxTv_SdtK2BNumericRangeSet_Item_Tovalue = value;
				SetDirty("Tovalue");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BNumericRangeSet_Item_Code = "";
			gxTv_SdtK2BNumericRangeSet_Item_Description = "";
			gxTv_SdtK2BNumericRangeSet_Item_Fromvalue = "";
			gxTv_SdtK2BNumericRangeSet_Item_Tovalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BNumericRangeSet_Item_Code;
		 

		protected String gxTv_SdtK2BNumericRangeSet_Item_Description;
		 

		protected String gxTv_SdtK2BNumericRangeSet_Item_Fromvalue;
		 

		protected String gxTv_SdtK2BNumericRangeSet_Item_Tovalue;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Item", Namespace="TABLEROS_WEB")]
	public class SdtK2BNumericRangeSet_Item_RESTInterface : GxGenericCollectionItem<SdtK2BNumericRangeSet_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BNumericRangeSet_Item_RESTInterface( ) : base()
		{
		}

		public SdtK2BNumericRangeSet_Item_RESTInterface( SdtK2BNumericRangeSet_Item psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  String gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  String gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="FromValue", Order=2)]
		public  String gxTpr_Fromvalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Fromvalue);

			}
			set { 
				 sdt.gxTpr_Fromvalue = value;
			}
		}

		[DataMember(Name="ToValue", Order=3)]
		public  String gxTpr_Tovalue
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tovalue);

			}
			set { 
				 sdt.gxTpr_Tovalue = value;
			}
		}


		#endregion

		public SdtK2BNumericRangeSet_Item sdt
		{
			get { 
				return (SdtK2BNumericRangeSet_Item)Sdt;
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
				sdt = new SdtK2BNumericRangeSet_Item() ;
			}
		}
	}
	#endregion
}