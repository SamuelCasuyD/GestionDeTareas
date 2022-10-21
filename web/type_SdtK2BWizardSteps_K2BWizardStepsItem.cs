/*
				   File: type_SdtK2BWizardSteps_K2BWizardStepsItem
			Description: K2BWizardSteps
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
	[XmlRoot(ElementName="K2BWizardStepsItem")]
	[XmlType(TypeName="K2BWizardStepsItem" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BWizardSteps_K2BWizardStepsItem : GxUserType
	{
		public SdtK2BWizardSteps_K2BWizardStepsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepname = "";

		}

		public SdtK2BWizardSteps_K2BWizardStepsItem(IGxContext context)
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
			AddObjectProperty("StepNumber", gxTpr_Stepnumber, false);


			AddObjectProperty("StepName", gxTpr_Stepname, false);


			AddObjectProperty("Available", gxTpr_Available, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="StepNumber")]
		[XmlElement(ElementName="StepNumber")]
		public short gxTpr_Stepnumber
		{
			get { 
				return gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepnumber; 
			}
			set { 
				gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepnumber = value;
				SetDirty("Stepnumber");
			}
		}




		[SoapElement(ElementName="StepName")]
		[XmlElement(ElementName="StepName")]
		public String gxTpr_Stepname
		{
			get { 
				return gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepname; 
			}
			set { 
				gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepname = value;
				SetDirty("Stepname");
			}
		}




		[SoapElement(ElementName="Available")]
		[XmlElement(ElementName="Available")]
		public bool gxTpr_Available
		{
			get { 
				return gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Available; 
			}
			set { 
				gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Available = value;
				SetDirty("Available");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepname = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepnumber;
		 

		protected String gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Stepname;
		 

		protected bool gxTv_SdtK2BWizardSteps_K2BWizardStepsItem_Available;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BWizardStepsItem", Namespace="TABLEROS_WEB")]
	public class SdtK2BWizardSteps_K2BWizardStepsItem_RESTInterface : GxGenericCollectionItem<SdtK2BWizardSteps_K2BWizardStepsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BWizardSteps_K2BWizardStepsItem_RESTInterface( ) : base()
		{
		}

		public SdtK2BWizardSteps_K2BWizardStepsItem_RESTInterface( SdtK2BWizardSteps_K2BWizardStepsItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="StepNumber", Order=0)]
		public short gxTpr_Stepnumber
		{
			get { 
				return sdt.gxTpr_Stepnumber;

			}
			set { 
				sdt.gxTpr_Stepnumber = value;
			}
		}

		[DataMember(Name="StepName", Order=1)]
		public  String gxTpr_Stepname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Stepname);

			}
			set { 
				 sdt.gxTpr_Stepname = value;
			}
		}

		[DataMember(Name="Available", Order=2)]
		public bool gxTpr_Available
		{
			get { 
				return sdt.gxTpr_Available;

			}
			set { 
				sdt.gxTpr_Available = value;
			}
		}


		#endregion

		public SdtK2BWizardSteps_K2BWizardStepsItem sdt
		{
			get { 
				return (SdtK2BWizardSteps_K2BWizardStepsItem)Sdt;
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
				sdt = new SdtK2BWizardSteps_K2BWizardStepsItem() ;
			}
		}
	}
	#endregion
}