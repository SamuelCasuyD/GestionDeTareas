/*
				   File: type_SdtTrComentarioTarea_SDT
			Description: TrComentarioTarea_SDT
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
	[XmlRoot(ElementName="TrComentarioTarea_SDT")]
	[XmlType(TypeName="TrComentarioTarea_SDT" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtTrComentarioTarea_SDT : GxUserType
	{
		public SdtTrComentarioTarea_SDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_descripcion = "";

		}

		public SdtTrComentarioTarea_SDT(IGxContext context)
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
			AddObjectProperty("TrTareaComentarios_ID", gxTpr_Trtareacomentarios_id, false);


			AddObjectProperty("TrTareaComentarios_IDTarea", gxTpr_Trtareacomentarios_idtarea, false);


			AddObjectProperty("TrTareaComentarios_Descripcion", gxTpr_Trtareacomentarios_descripcion, false);


			AddObjectProperty("TrTareaComentarios_Estado", gxTpr_Trtareacomentarios_estado, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trtareacomentarios_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trtareacomentarios_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trtareacomentarios_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrTareaComentarios_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trtareacomentarios_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trtareacomentarios_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trtareacomentarios_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrTareaComentarios_FechaModificacion", sDateCnv, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrTareaComentarios_ID")]
		[XmlElement(ElementName="TrTareaComentarios_ID")]
		public long gxTpr_Trtareacomentarios_id
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_id; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_id = value;
				SetDirty("Trtareacomentarios_id");
			}
		}




		[SoapElement(ElementName="TrTareaComentarios_IDTarea")]
		[XmlElement(ElementName="TrTareaComentarios_IDTarea")]
		public long gxTpr_Trtareacomentarios_idtarea
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_idtarea; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_idtarea = value;
				SetDirty("Trtareacomentarios_idtarea");
			}
		}




		[SoapElement(ElementName="TrTareaComentarios_Descripcion")]
		[XmlElement(ElementName="TrTareaComentarios_Descripcion")]
		public String gxTpr_Trtareacomentarios_descripcion
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_descripcion; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_descripcion = value;
				SetDirty("Trtareacomentarios_descripcion");
			}
		}




		[SoapElement(ElementName="TrTareaComentarios_Estado")]
		[XmlElement(ElementName="TrTareaComentarios_Estado")]
		public short gxTpr_Trtareacomentarios_estado
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_estado; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_estado = value;
				SetDirty("Trtareacomentarios_estado");
			}
		}



		[SoapElement(ElementName="TrTareaComentarios_FechaCreacion")]
		[XmlElement(ElementName="TrTareaComentarios_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Trtareacomentarios_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion).value ;
			}
			set {
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trtareacomentarios_fechacreacion
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion = value;
				SetDirty("Trtareacomentarios_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrTareaComentarios_FechaModificacion")]
		[XmlElement(ElementName="TrTareaComentarios_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Trtareacomentarios_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion).value ;
			}
			set {
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trtareacomentarios_fechamodificacion
		{
			get { 
				return gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion; 
			}
			set { 
				gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion = value;
				SetDirty("Trtareacomentarios_fechamodificacion");
			}
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_descripcion = "";



			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String sDateCnv ;
		protected String sNumToPad ;
		protected long gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_id;
		 

		protected long gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_idtarea;
		 

		protected String gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_descripcion;
		 

		protected short gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_estado;
		 

		protected DateTime gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechacreacion;
		 

		protected DateTime gxTv_SdtTrComentarioTarea_SDT_Trtareacomentarios_fechamodificacion;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TrComentarioTarea_SDT", Namespace="TABLEROS_WEB")]
	public class SdtTrComentarioTarea_SDT_RESTInterface : GxGenericCollectionItem<SdtTrComentarioTarea_SDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTrComentarioTarea_SDT_RESTInterface( ) : base()
		{
		}

		public SdtTrComentarioTarea_SDT_RESTInterface( SdtTrComentarioTarea_SDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TrTareaComentarios_ID", Order=0)]
		public  String gxTpr_Trtareacomentarios_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Trtareacomentarios_id, 13, 0));

			}
			set { 
				sdt.gxTpr_Trtareacomentarios_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrTareaComentarios_IDTarea", Order=1)]
		public  String gxTpr_Trtareacomentarios_idtarea
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Trtareacomentarios_idtarea, 13, 0));

			}
			set { 
				sdt.gxTpr_Trtareacomentarios_idtarea = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrTareaComentarios_Descripcion", Order=2)]
		public  String gxTpr_Trtareacomentarios_descripcion
		{
			get { 
				return sdt.gxTpr_Trtareacomentarios_descripcion;

			}
			set { 
				 sdt.gxTpr_Trtareacomentarios_descripcion = value;
			}
		}

		[DataMember(Name="TrTareaComentarios_Estado", Order=3)]
		public short gxTpr_Trtareacomentarios_estado
		{
			get { 
				return sdt.gxTpr_Trtareacomentarios_estado;

			}
			set { 
				sdt.gxTpr_Trtareacomentarios_estado = value;
			}
		}

		[DataMember(Name="TrTareaComentarios_FechaCreacion", Order=4)]
		public  String gxTpr_Trtareacomentarios_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trtareacomentarios_fechacreacion);

			}
			set { 
				sdt.gxTpr_Trtareacomentarios_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrTareaComentarios_FechaModificacion", Order=5)]
		public  String gxTpr_Trtareacomentarios_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trtareacomentarios_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Trtareacomentarios_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}


		#endregion

		public SdtTrComentarioTarea_SDT sdt
		{
			get { 
				return (SdtTrComentarioTarea_SDT)Sdt;
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
				sdt = new SdtTrComentarioTarea_SDT() ;
			}
		}
	}
	#endregion
}