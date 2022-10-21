using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exporttrgestiontablerostrgestiontareaswc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            if ( ! entryPointCalled )
            {
               AV9TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( gxfirstwebparm));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11OrderedBy = (short)(NumberUtil.Val( GetNextPar( ), "."));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public exporttrgestiontablerostrgestiontareaswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public exporttrgestiontablerostrgestiontareaswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( Guid aP0_TrGestionTareas_IDTablero ,
                           short aP1_OrderedBy )
      {
         this.AV9TrGestionTareas_IDTablero = aP0_TrGestionTareas_IDTablero;
         this.AV11OrderedBy = aP1_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( Guid aP0_TrGestionTareas_IDTablero ,
                                 short aP1_OrderedBy )
      {
         exporttrgestiontablerostrgestiontareaswc objexporttrgestiontablerostrgestiontareaswc;
         objexporttrgestiontablerostrgestiontareaswc = new exporttrgestiontablerostrgestiontareaswc();
         objexporttrgestiontablerostrgestiontareaswc.AV9TrGestionTareas_IDTablero = aP0_TrGestionTareas_IDTablero;
         objexporttrgestiontablerostrgestiontareaswc.AV11OrderedBy = aP1_OrderedBy;
         objexporttrgestiontablerostrgestiontareaswc.context.SetSubmitInitialConfig(context);
         objexporttrgestiontablerostrgestiontareaswc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexporttrgestiontablerostrgestiontareaswc);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exporttrgestiontablerostrgestiontareaswc)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTareas",  "TrGestionTareas",  "List",  "",  AV47Pgmname) )
         {
            AV12Filename = "";
            AV13ErrorMessage = "You are not authorized to do activity ";
            AV13ErrorMessage = AV13ErrorMessage + "EntityName:" + "TrGestionTareas";
            AV13ErrorMessage = AV13ErrorMessage + "TransactionName:" + "TrGestionTareas";
            AV13ErrorMessage = AV13ErrorMessage + "ActivityType:" + "List";
            AV13ErrorMessage = AV13ErrorMessage + " PgmName:" + AV47Pgmname;
            AV36HttpResponse.AddString(AV13ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV8Context) ;
         AV34Random = (int)(NumberUtil.Random( )*10000);
         AV12Filename = GxDirectory.TemporaryFilesPath + AV37File.Separator + "ExportTrGestionTablerosTrGestionTareasWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV34Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Clear();
         AV14ExcelDocument.AutoFit = 1;
         AV32CellRow = 1;
         AV33FirstColumn = 1;
         AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn, 1, 1).Size = 15;
         AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn, 1, 1).Bold = 1;
         AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn, 1, 1).Text = "Tr Gestion Tareas";
         AV32CellRow = (int)(AV32CellRow+4);
         /* Using cursor P002I2 */
         pr_default.execute(0, new Object[] {AV9TrGestionTareas_IDTablero});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1TrGestionTableros_ID = (Guid)((Guid)(P002I2_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = P002I2_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = P002I2_n2TrGestionTableros_Nombre[0];
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+0, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+0, 1, 1).Text = "del tablero";
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A2TrGestionTableros_Nombre);
            AV32CellRow = (int)(AV32CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV32CellRow = (int)(AV32CellRow+3);
         AV35ColumnIndex = 0;
         if ( AV38GridColumnVisible_TrGestionTareas_ID )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Gestion Tareas_ID";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_TrGestionTareas_Nombre )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Gestion Tareas_Nombre";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_TrGestionTareas_Descripcion )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Gestion Tareas_Descripcion";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_TrGestionTareas_FechaInicio )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Tareas_Fecha Inicio";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_TrGestionTareas_FechaFin )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Tareas_Fecha Fin";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_TrGestionTareas_FechaCreacion )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Tareas_Fecha Creacion";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_TrGestionTareas_FechaModificacion )
         {
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Bold = 1;
            AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = "Tareas_Fecha Modificacion";
            AV35ColumnIndex = (short)(AV35ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11OrderedBy ,
                                              AV9TrGestionTareas_IDTablero ,
                                              A11TrGestionTareas_IDTablero } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         } ) ;
         /* Using cursor P002I3 */
         pr_default.execute(1, new Object[] {AV9TrGestionTareas_IDTablero});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(P002I3_A11TrGestionTareas_IDTablero[0]));
            A14TrGestionTareas_Descripcion = P002I3_A14TrGestionTareas_Descripcion[0];
            n14TrGestionTareas_Descripcion = P002I3_n14TrGestionTareas_Descripcion[0];
            A15TrGestionTareas_FechaInicio = P002I3_A15TrGestionTareas_FechaInicio[0];
            n15TrGestionTareas_FechaInicio = P002I3_n15TrGestionTareas_FechaInicio[0];
            A16TrGestionTareas_FechaFin = P002I3_A16TrGestionTareas_FechaFin[0];
            n16TrGestionTareas_FechaFin = P002I3_n16TrGestionTareas_FechaFin[0];
            A17TrGestionTareas_FechaCreacion = P002I3_A17TrGestionTareas_FechaCreacion[0];
            n17TrGestionTareas_FechaCreacion = P002I3_n17TrGestionTareas_FechaCreacion[0];
            A18TrGestionTareas_FechaModificacion = P002I3_A18TrGestionTareas_FechaModificacion[0];
            n18TrGestionTareas_FechaModificacion = P002I3_n18TrGestionTareas_FechaModificacion[0];
            A13TrGestionTareas_Nombre = P002I3_A13TrGestionTareas_Nombre[0];
            n13TrGestionTareas_Nombre = P002I3_n13TrGestionTareas_Nombre[0];
            A12TrGestionTareas_ID = P002I3_A12TrGestionTareas_ID[0];
            AV32CellRow = (int)(AV32CellRow+1);
            AV35ColumnIndex = 0;
            if ( AV38GridColumnVisible_TrGestionTareas_ID )
            {
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Number = A12TrGestionTareas_ID;
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_TrGestionTareas_Nombre )
            {
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = StringUtil.RTrim( A13TrGestionTareas_Nombre);
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_TrGestionTareas_Descripcion )
            {
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Text = StringUtil.Substring( StringUtil.RTrim( A14TrGestionTareas_Descripcion), 1, 1000);
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_TrGestionTareas_FechaInicio )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A15TrGestionTareas_FechaInicio ) ;
               AV14ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_TrGestionTareas_FechaFin )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A16TrGestionTareas_FechaFin ) ;
               AV14ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_TrGestionTareas_FechaCreacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A17TrGestionTareas_FechaCreacion ) ;
               AV14ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_TrGestionTareas_FechaModificacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A18TrGestionTareas_FechaModificacion ) ;
               AV14ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV14ExcelDocument.get_Cells(AV32CellRow, AV33FirstColumn+AV35ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV35ColumnIndex = (short)(AV35ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV14ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV36HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV36HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportTrGestionTablerosTrGestionTareasWC.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV36HttpResponse.AppendHeader("X-Frame-Options", "deny");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV36HttpResponse.AppendHeader("X-Content-Type-Options", " nosniff");
         }
         AV36HttpResponse.AddFile(AV12Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV12Filename) ;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         if ( AV14ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV14ExcelDocument.ErrDescription;
            AV36HttpResponse.AddString(AV13ErrorMessage);
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S131 ();
         if (returnInSub) return;
         new k2bloadgridcolumns(context ).execute(  "TrGestionTablerosTrGestionTareasWC",  "Grid", ref  AV15GridColumns) ;
         AV38GridColumnVisible_TrGestionTareas_ID = true;
         AV39GridColumnVisible_TrGestionTareas_Nombre = true;
         AV40GridColumnVisible_TrGestionTareas_Descripcion = true;
         AV41GridColumnVisible_TrGestionTareas_FechaInicio = true;
         AV42GridColumnVisible_TrGestionTareas_FechaFin = true;
         AV43GridColumnVisible_TrGestionTareas_FechaCreacion = true;
         AV44GridColumnVisible_TrGestionTareas_FechaModificacion = true;
         new k2bsavegridcolumns(context ).execute(  "TrGestionTablerosTrGestionTareasWC",  "Grid",  AV15GridColumns,  false) ;
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV15GridColumns.Count )
         {
            AV16GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV15GridColumns.Item(AV50GXV1));
            if ( ! AV16GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_ID") == 0 )
               {
                  AV38GridColumnVisible_TrGestionTareas_ID = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_Nombre") == 0 )
               {
                  AV39GridColumnVisible_TrGestionTareas_Nombre = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_Descripcion") == 0 )
               {
                  AV40GridColumnVisible_TrGestionTareas_Descripcion = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaInicio") == 0 )
               {
                  AV41GridColumnVisible_TrGestionTareas_FechaInicio = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaFin") == 0 )
               {
                  AV42GridColumnVisible_TrGestionTareas_FechaFin = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaCreacion") == 0 )
               {
                  AV43GridColumnVisible_TrGestionTareas_FechaCreacion = false;
               }
               else if ( StringUtil.StrCmp(AV16GridColumn.gxTpr_Attributename, "TrGestionTareas_FechaModificacion") == 0 )
               {
                  AV44GridColumnVisible_TrGestionTareas_FechaModificacion = false;
               }
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         AV15GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_ID";
         AV16GridColumn.gxTpr_Columntitle = "Gestion Tareas_ID";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_Nombre";
         AV16GridColumn.gxTpr_Columntitle = "Gestion Tareas_Nombre";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_Descripcion";
         AV16GridColumn.gxTpr_Columntitle = "Gestion Tareas_Descripcion";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaInicio";
         AV16GridColumn.gxTpr_Columntitle = "Tareas_Fecha Inicio";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaFin";
         AV16GridColumn.gxTpr_Columntitle = "Tareas_Fecha Fin";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaCreacion";
         AV16GridColumn.gxTpr_Columntitle = "Tareas_Fecha Creacion";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV16GridColumn.gxTpr_Attributename = "TrGestionTareas_FechaModificacion";
         AV16GridColumn.gxTpr_Columntitle = "Tareas_Fecha Modificacion";
         AV16GridColumn.gxTpr_Showattribute = true;
         AV15GridColumns.Add(AV16GridColumn, 0);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV47Pgmname = "";
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV36HttpResponse = new GxHttpResponse( context);
         AV8Context = new SdtK2BContext(context);
         AV37File = new GxFile(context.GetPhysicalPath());
         AV14ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P002I2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         P002I2_A2TrGestionTableros_Nombre = new String[] {""} ;
         P002I2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         P002I3_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         P002I3_A14TrGestionTareas_Descripcion = new String[] {""} ;
         P002I3_n14TrGestionTareas_Descripcion = new bool[] {false} ;
         P002I3_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002I3_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         P002I3_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         P002I3_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         P002I3_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         P002I3_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         P002I3_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         P002I3_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         P002I3_A13TrGestionTareas_Nombre = new String[] {""} ;
         P002I3_n13TrGestionTareas_Nombre = new bool[] {false} ;
         P002I3_A12TrGestionTareas_ID = new long[1] ;
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         A13TrGestionTareas_Nombre = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV15GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV16GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exporttrgestiontablerostrgestiontareaswc__default(),
            new Object[][] {
                new Object[] {
               P002I2_A1TrGestionTableros_ID, P002I2_A2TrGestionTableros_Nombre, P002I2_n2TrGestionTableros_Nombre
               }
               , new Object[] {
               P002I3_A11TrGestionTareas_IDTablero, P002I3_A14TrGestionTareas_Descripcion, P002I3_n14TrGestionTareas_Descripcion, P002I3_A15TrGestionTareas_FechaInicio, P002I3_n15TrGestionTareas_FechaInicio, P002I3_A16TrGestionTareas_FechaFin, P002I3_n16TrGestionTareas_FechaFin, P002I3_A17TrGestionTareas_FechaCreacion, P002I3_n17TrGestionTareas_FechaCreacion, P002I3_A18TrGestionTareas_FechaModificacion,
               P002I3_n18TrGestionTareas_FechaModificacion, P002I3_A13TrGestionTareas_Nombre, P002I3_n13TrGestionTareas_Nombre, P002I3_A12TrGestionTareas_ID
               }
            }
         );
         AV47Pgmname = "ExportTrGestionTablerosTrGestionTareasWC";
         /* GeneXus formulas. */
         AV47Pgmname = "ExportTrGestionTablerosTrGestionTareasWC";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private short AV35ColumnIndex ;
      private int AV34Random ;
      private int AV32CellRow ;
      private int AV33FirstColumn ;
      private int AV50GXV1 ;
      private long A12TrGestionTareas_ID ;
      private String GXKey ;
      private String gxfirstwebparm ;
      private String AV47Pgmname ;
      private String scmdbuf ;
      private String A2TrGestionTableros_Nombre ;
      private String A13TrGestionTareas_Nombre ;
      private DateTime GXt_dtime1 ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime A17TrGestionTareas_FechaCreacion ;
      private DateTime A18TrGestionTareas_FechaModificacion ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool n2TrGestionTableros_Nombre ;
      private bool AV38GridColumnVisible_TrGestionTareas_ID ;
      private bool AV39GridColumnVisible_TrGestionTareas_Nombre ;
      private bool AV40GridColumnVisible_TrGestionTareas_Descripcion ;
      private bool AV41GridColumnVisible_TrGestionTareas_FechaInicio ;
      private bool AV42GridColumnVisible_TrGestionTareas_FechaFin ;
      private bool AV43GridColumnVisible_TrGestionTareas_FechaCreacion ;
      private bool AV44GridColumnVisible_TrGestionTareas_FechaModificacion ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n17TrGestionTareas_FechaCreacion ;
      private bool n18TrGestionTareas_FechaModificacion ;
      private bool n13TrGestionTareas_Nombre ;
      private String A14TrGestionTareas_Descripcion ;
      private String AV12Filename ;
      private String AV13ErrorMessage ;
      private Guid AV9TrGestionTareas_IDTablero ;
      private Guid A1TrGestionTableros_ID ;
      private Guid A11TrGestionTareas_IDTablero ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P002I2_A1TrGestionTableros_ID ;
      private String[] P002I2_A2TrGestionTableros_Nombre ;
      private bool[] P002I2_n2TrGestionTableros_Nombre ;
      private Guid[] P002I3_A11TrGestionTareas_IDTablero ;
      private String[] P002I3_A14TrGestionTareas_Descripcion ;
      private bool[] P002I3_n14TrGestionTareas_Descripcion ;
      private DateTime[] P002I3_A15TrGestionTareas_FechaInicio ;
      private bool[] P002I3_n15TrGestionTareas_FechaInicio ;
      private DateTime[] P002I3_A16TrGestionTareas_FechaFin ;
      private bool[] P002I3_n16TrGestionTareas_FechaFin ;
      private DateTime[] P002I3_A17TrGestionTareas_FechaCreacion ;
      private bool[] P002I3_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] P002I3_A18TrGestionTareas_FechaModificacion ;
      private bool[] P002I3_n18TrGestionTareas_FechaModificacion ;
      private String[] P002I3_A13TrGestionTareas_Nombre ;
      private bool[] P002I3_n13TrGestionTareas_Nombre ;
      private long[] P002I3_A12TrGestionTareas_ID ;
      private GxHttpResponse AV36HttpResponse ;
      private ExcelDocumentI AV14ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV15GridColumns ;
      private GxFile AV37File ;
      private SdtK2BContext AV8Context ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV16GridColumn ;
   }

   public class exporttrgestiontablerostrgestiontareaswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002I3( IGxContext context ,
                                             short AV11OrderedBy ,
                                             Guid AV9TrGestionTareas_IDTablero ,
                                             Guid A11TrGestionTareas_IDTablero )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int2 ;
         GXv_int2 = new short [1] ;
         Object[] GXv_Object3 ;
         GXv_Object3 = new Object [2] ;
         scmdbuf = "SELECT [TrGestionTareas_IDTablero], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaModificacion], [TrGestionTareas_Nombre], [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas]";
         scmdbuf = scmdbuf + " WHERE ([TrGestionTareas_IDTablero] = @AV9TrGestionTareas_IDTablero)";
         if ( AV11OrderedBy == 0 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTareas_ID]";
         }
         else if ( AV11OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTareas_ID] DESC";
         }
         else if ( AV11OrderedBy == 2 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTareas_Nombre]";
         }
         else if ( AV11OrderedBy == 3 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTareas_Nombre] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P002I3(context, (short)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002I2 ;
          prmP002I2 = new Object[] {
          new Object[] {"@AV9TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP002I3 ;
          prmP002I3 = new Object[] {
          new Object[] {"@AV9TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P002I2", "SELECT TOP 1 [TrGestionTableros_ID], [TrGestionTableros_Nombre] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @AV9TrGestionTareas_IDTablero ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((String[]) buf[11])[0] = rslt.getString(7, 100) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[1]);
                }
                return;
       }
    }

 }

}
