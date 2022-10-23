/*
				   File: type_SdtGestionActividades_SDT
			Description: GestionActividades_SDT
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
	[XmlRoot(ElementName="GestionActividades_SDT")]
	[XmlType(TypeName="GestionActividades_SDT" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtGestionActividades_SDT : GxUserType
	{
		public SdtGestionActividades_SDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtGestionActividades_SDT_Tractividades_nombre = "";

			gxTv_SdtGestionActividades_SDT_Tractividades_descripcion = "";

			gxTv_SdtGestionActividades_SDT_Trlistaactividad_nombre = "";

			gxTv_SdtGestionActividades_SDT_Trlistaactividad_descripcion = "";

		}

		public SdtGestionActividades_SDT(IGxContext context)
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
			AddObjectProperty("TrActividades_ID", gxTpr_Tractividades_id, false);


			AddObjectProperty("TrActividades_IDTarea", gxTpr_Tractividades_idtarea, false);


			AddObjectProperty("TrActividades_Nombre", gxTpr_Tractividades_nombre, false);


			AddObjectProperty("TrActividades_Descripcion", gxTpr_Tractividades_descripcion, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tractividades_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tractividades_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tractividades_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrActividades_FechaInicio", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tractividades_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tractividades_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tractividades_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrActividades_FechaFin", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tractividades_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tractividades_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tractividades_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrActividades_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tractividades_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tractividades_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tractividades_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrActividades_FechaModificacion", sDateCnv, false);


			AddObjectProperty("TrActividades_Estado", gxTpr_Tractividades_estado, false);


			AddObjectProperty("TrListaActividad_ID", gxTpr_Trlistaactividad_id, false);


			AddObjectProperty("TrListaActividad_Nombre", gxTpr_Trlistaactividad_nombre, false);


			AddObjectProperty("TrListaActividad_Descripcion", gxTpr_Trlistaactividad_descripcion, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trlistaactividad_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trlistaactividad_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trlistaactividad_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrListaActividad_FechaInicio", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trlistaactividad_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trlistaactividad_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trlistaactividad_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrListaActividad_FechaFin", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trlistaactividad_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trlistaactividad_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trlistaactividad_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrListaActividad_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trlistaactividad_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trlistaactividad_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trlistaactividad_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrListaActividad_FechaModificacion", sDateCnv, false);


			AddObjectProperty("TrListaActividad_Estado", gxTpr_Trlistaactividad_estado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrActividades_ID")]
		[XmlElement(ElementName="TrActividades_ID")]
		public long gxTpr_Tractividades_id
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_id; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_id = value;
				SetDirty("Tractividades_id");
			}
		}




		[SoapElement(ElementName="TrActividades_IDTarea")]
		[XmlElement(ElementName="TrActividades_IDTarea")]
		public long gxTpr_Tractividades_idtarea
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_idtarea; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_idtarea = value;
				SetDirty("Tractividades_idtarea");
			}
		}




		[SoapElement(ElementName="TrActividades_Nombre")]
		[XmlElement(ElementName="TrActividades_Nombre")]
		public String gxTpr_Tractividades_nombre
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_nombre; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_nombre = value;
				SetDirty("Tractividades_nombre");
			}
		}




		[SoapElement(ElementName="TrActividades_Descripcion")]
		[XmlElement(ElementName="TrActividades_Descripcion")]
		public String gxTpr_Tractividades_descripcion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_descripcion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_descripcion = value;
				SetDirty("Tractividades_descripcion");
			}
		}



		[SoapElement(ElementName="TrActividades_FechaInicio")]
		[XmlElement(ElementName="TrActividades_FechaInicio" , IsNullable=true)]
		public string gxTpr_Tractividades_fechainicio_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tractividades_fechainicio
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio = value;
				SetDirty("Tractividades_fechainicio");
			}
		}


		[SoapElement(ElementName="TrActividades_FechaFin")]
		[XmlElement(ElementName="TrActividades_FechaFin" , IsNullable=true)]
		public string gxTpr_Tractividades_fechafin_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Tractividades_fechafin == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Tractividades_fechafin).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Tractividades_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tractividades_fechafin
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_fechafin; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_fechafin = value;
				SetDirty("Tractividades_fechafin");
			}
		}


		[SoapElement(ElementName="TrActividades_FechaCreacion")]
		[XmlElement(ElementName="TrActividades_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Tractividades_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tractividades_fechacreacion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion = value;
				SetDirty("Tractividades_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrActividades_FechaModificacion")]
		[XmlElement(ElementName="TrActividades_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Tractividades_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tractividades_fechamodificacion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion = value;
				SetDirty("Tractividades_fechamodificacion");
			}
		}



		[SoapElement(ElementName="TrActividades_Estado")]
		[XmlElement(ElementName="TrActividades_Estado")]
		public short gxTpr_Tractividades_estado
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Tractividades_estado; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Tractividades_estado = value;
				SetDirty("Tractividades_estado");
			}
		}




		[SoapElement(ElementName="TrListaActividad_ID")]
		[XmlElement(ElementName="TrListaActividad_ID")]
		public Guid gxTpr_Trlistaactividad_id
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_id; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_id = value;
				SetDirty("Trlistaactividad_id");
			}
		}




		[SoapElement(ElementName="TrListaActividad_Nombre")]
		[XmlElement(ElementName="TrListaActividad_Nombre")]
		public String gxTpr_Trlistaactividad_nombre
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_nombre; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_nombre = value;
				SetDirty("Trlistaactividad_nombre");
			}
		}




		[SoapElement(ElementName="TrListaActividad_Descripcion")]
		[XmlElement(ElementName="TrListaActividad_Descripcion")]
		public String gxTpr_Trlistaactividad_descripcion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_descripcion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_descripcion = value;
				SetDirty("Trlistaactividad_descripcion");
			}
		}



		[SoapElement(ElementName="TrListaActividad_FechaInicio")]
		[XmlElement(ElementName="TrListaActividad_FechaInicio" , IsNullable=true)]
		public string gxTpr_Trlistaactividad_fechainicio_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trlistaactividad_fechainicio
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio = value;
				SetDirty("Trlistaactividad_fechainicio");
			}
		}


		[SoapElement(ElementName="TrListaActividad_FechaFin")]
		[XmlElement(ElementName="TrListaActividad_FechaFin" , IsNullable=true)]
		public string gxTpr_Trlistaactividad_fechafin_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trlistaactividad_fechafin
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin = value;
				SetDirty("Trlistaactividad_fechafin");
			}
		}


		[SoapElement(ElementName="TrListaActividad_FechaCreacion")]
		[XmlElement(ElementName="TrListaActividad_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Trlistaactividad_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trlistaactividad_fechacreacion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion = value;
				SetDirty("Trlistaactividad_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrListaActividad_FechaModificacion")]
		[XmlElement(ElementName="TrListaActividad_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Trlistaactividad_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion).value ;
			}
			set {
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trlistaactividad_fechamodificacion
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion = value;
				SetDirty("Trlistaactividad_fechamodificacion");
			}
		}



		[SoapElement(ElementName="TrListaActividad_Estado")]
		[XmlElement(ElementName="TrListaActividad_Estado")]
		public short gxTpr_Trlistaactividad_estado
		{
			get { 
				return gxTv_SdtGestionActividades_SDT_Trlistaactividad_estado; 
			}
			set { 
				gxTv_SdtGestionActividades_SDT_Trlistaactividad_estado = value;
				SetDirty("Trlistaactividad_estado");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGestionActividades_SDT_Tractividades_nombre = "";
			gxTv_SdtGestionActividades_SDT_Tractividades_descripcion = "";






			gxTv_SdtGestionActividades_SDT_Trlistaactividad_nombre = "";
			gxTv_SdtGestionActividades_SDT_Trlistaactividad_descripcion = "";





			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String sDateCnv ;
		protected String sNumToPad ;
		protected long gxTv_SdtGestionActividades_SDT_Tractividades_id;
		 

		protected long gxTv_SdtGestionActividades_SDT_Tractividades_idtarea;
		 

		protected String gxTv_SdtGestionActividades_SDT_Tractividades_nombre;
		 

		protected String gxTv_SdtGestionActividades_SDT_Tractividades_descripcion;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Tractividades_fechainicio;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Tractividades_fechafin;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Tractividades_fechacreacion;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Tractividades_fechamodificacion;
		 

		protected short gxTv_SdtGestionActividades_SDT_Tractividades_estado;
		 

		protected Guid gxTv_SdtGestionActividades_SDT_Trlistaactividad_id;
		 

		protected String gxTv_SdtGestionActividades_SDT_Trlistaactividad_nombre;
		 

		protected String gxTv_SdtGestionActividades_SDT_Trlistaactividad_descripcion;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechainicio;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechafin;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechacreacion;
		 

		protected DateTime gxTv_SdtGestionActividades_SDT_Trlistaactividad_fechamodificacion;
		 

		protected short gxTv_SdtGestionActividades_SDT_Trlistaactividad_estado;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GestionActividades_SDT", Namespace="TABLEROS_WEB")]
	public class SdtGestionActividades_SDT_RESTInterface : GxGenericCollectionItem<SdtGestionActividades_SDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGestionActividades_SDT_RESTInterface( ) : base()
		{
		}

		public SdtGestionActividades_SDT_RESTInterface( SdtGestionActividades_SDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TrActividades_ID", Order=0)]
		public  String gxTpr_Tractividades_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tractividades_id, 13, 0));

			}
			set { 
				sdt.gxTpr_Tractividades_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrActividades_IDTarea", Order=1)]
		public  String gxTpr_Tractividades_idtarea
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tractividades_idtarea, 13, 0));

			}
			set { 
				sdt.gxTpr_Tractividades_idtarea = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrActividades_Nombre", Order=2)]
		public  String gxTpr_Tractividades_nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tractividades_nombre);

			}
			set { 
				 sdt.gxTpr_Tractividades_nombre = value;
			}
		}

		[DataMember(Name="TrActividades_Descripcion", Order=3)]
		public  String gxTpr_Tractividades_descripcion
		{
			get { 
				return sdt.gxTpr_Tractividades_descripcion;

			}
			set { 
				 sdt.gxTpr_Tractividades_descripcion = value;
			}
		}

		[DataMember(Name="TrActividades_FechaInicio", Order=4)]
		public  String gxTpr_Tractividades_fechainicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tractividades_fechainicio);

			}
			set { 
				sdt.gxTpr_Tractividades_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrActividades_FechaFin", Order=5)]
		public  String gxTpr_Tractividades_fechafin
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tractividades_fechafin);

			}
			set { 
				sdt.gxTpr_Tractividades_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrActividades_FechaCreacion", Order=6)]
		public  String gxTpr_Tractividades_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tractividades_fechacreacion);

			}
			set { 
				sdt.gxTpr_Tractividades_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrActividades_FechaModificacion", Order=7)]
		public  String gxTpr_Tractividades_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tractividades_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Tractividades_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrActividades_Estado", Order=8)]
		public short gxTpr_Tractividades_estado
		{
			get { 
				return sdt.gxTpr_Tractividades_estado;

			}
			set { 
				sdt.gxTpr_Tractividades_estado = value;
			}
		}

		[DataMember(Name="TrListaActividad_ID", Order=9)]
		public Guid gxTpr_Trlistaactividad_id
		{
			get { 
				return sdt.gxTpr_Trlistaactividad_id;

			}
			set { 
				sdt.gxTpr_Trlistaactividad_id = value;
			}
		}

		[DataMember(Name="TrListaActividad_Nombre", Order=10)]
		public  String gxTpr_Trlistaactividad_nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Trlistaactividad_nombre);

			}
			set { 
				 sdt.gxTpr_Trlistaactividad_nombre = value;
			}
		}

		[DataMember(Name="TrListaActividad_Descripcion", Order=11)]
		public  String gxTpr_Trlistaactividad_descripcion
		{
			get { 
				return sdt.gxTpr_Trlistaactividad_descripcion;

			}
			set { 
				 sdt.gxTpr_Trlistaactividad_descripcion = value;
			}
		}

		[DataMember(Name="TrListaActividad_FechaInicio", Order=12)]
		public  String gxTpr_Trlistaactividad_fechainicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trlistaactividad_fechainicio);

			}
			set { 
				sdt.gxTpr_Trlistaactividad_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrListaActividad_FechaFin", Order=13)]
		public  String gxTpr_Trlistaactividad_fechafin
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trlistaactividad_fechafin);

			}
			set { 
				sdt.gxTpr_Trlistaactividad_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrListaActividad_FechaCreacion", Order=14)]
		public  String gxTpr_Trlistaactividad_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trlistaactividad_fechacreacion);

			}
			set { 
				sdt.gxTpr_Trlistaactividad_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrListaActividad_FechaModificacion", Order=15)]
		public  String gxTpr_Trlistaactividad_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trlistaactividad_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Trlistaactividad_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrListaActividad_Estado", Order=16)]
		public short gxTpr_Trlistaactividad_estado
		{
			get { 
				return sdt.gxTpr_Trlistaactividad_estado;

			}
			set { 
				sdt.gxTpr_Trlistaactividad_estado = value;
			}
		}


		#endregion

		public SdtGestionActividades_SDT sdt
		{
			get { 
				return (SdtGestionActividades_SDT)Sdt;
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
				sdt = new SdtGestionActividades_SDT() ;
			}
		}
	}
	#endregion
}