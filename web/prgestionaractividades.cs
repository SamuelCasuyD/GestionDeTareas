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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prgestionaractividades : GXProcedure
   {
      public prgestionaractividades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public prgestionaractividades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( SdtGestionActividades_SDT aP0_GestionActividades_SDT ,
                           String aP1_Modo )
      {
         this.AV8GestionActividades_SDT = aP0_GestionActividades_SDT;
         this.AV10Modo = aP1_Modo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtGestionActividades_SDT aP0_GestionActividades_SDT ,
                                 String aP1_Modo )
      {
         prgestionaractividades objprgestionaractividades;
         objprgestionaractividades = new prgestionaractividades();
         objprgestionaractividades.AV8GestionActividades_SDT = aP0_GestionActividades_SDT;
         objprgestionaractividades.AV10Modo = aP1_Modo;
         objprgestionaractividades.context.SetSubmitInitialConfig(context);
         objprgestionaractividades.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprgestionaractividades);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prgestionaractividades)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV10Modo, "INS") == 0 )
         {
            /* Execute user subroutine: 'NUEVAACTIVIDAD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Actividad creada exitosamente...!!!");
         }
         else if ( StringUtil.StrCmp(AV10Modo, "UDP") == 0 )
         {
            /* Execute user subroutine: 'ACTUALIZARACTIVIDAD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tarea actualizada");
         }
         else if ( StringUtil.StrCmp(AV10Modo, "AIN") == 0 )
         {
            /* Execute user subroutine: 'AGREGARACTIVIDAD' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Se agrego una nueva actividad");
         }
         else if ( StringUtil.StrCmp(AV10Modo, "ADE") == 0 )
         {
            /* Execute user subroutine: 'ELIMINARLISTAACTIVIDAD' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("La actividad fue elimanada exitosamente.");
         }
         else if ( StringUtil.StrCmp(AV10Modo, "AUD") == 0 )
         {
            /* Execute user subroutine: 'ACTUALIZARLISTAACTIVIDAD' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Actividad modificada exitosamente");
         }
         context.CommitDataStores("prgestionaractividades",pr_default);
         this.cleanup();
         if (true) return;
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NUEVAACTIVIDAD' Routine */
         /*
            INSERT RECORD ON TABLE TrActividades

         */
         A25TrActividades_IDTarea = AV8GestionActividades_SDT.gxTpr_Tractividades_idtarea;
         n25TrActividades_IDTarea = false;
         A27TrActividades_Nombre = AV8GestionActividades_SDT.gxTpr_Tractividades_nombre;
         n27TrActividades_Nombre = false;
         A28TrActividades_Descripcion = AV8GestionActividades_SDT.gxTpr_Tractividades_descripcion;
         n28TrActividades_Descripcion = false;
         A29TrActividades_FechaInicio = AV8GestionActividades_SDT.gxTpr_Tractividades_fechainicio;
         n29TrActividades_FechaInicio = false;
         A30TrActividades_FechaFin = AV8GestionActividades_SDT.gxTpr_Tractividades_fechafin;
         n30TrActividades_FechaFin = false;
         A31TrActividades_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n31TrActividades_FechaCreacion = false;
         A33TrActividades_Estado = AV8GestionActividades_SDT.gxTpr_Tractividades_estado;
         n33TrActividades_Estado = false;
         /* Using cursor P002O2 */
         pr_default.execute(0, new Object[] {n25TrActividades_IDTarea, A25TrActividades_IDTarea, n27TrActividades_Nombre, A27TrActividades_Nombre, n28TrActividades_Descripcion, A28TrActividades_Descripcion, n29TrActividades_FechaInicio, A29TrActividades_FechaInicio, n30TrActividades_FechaFin, A30TrActividades_FechaFin, n31TrActividades_FechaCreacion, A31TrActividades_FechaCreacion, n33TrActividades_Estado, A33TrActividades_Estado});
         A26TrActividades_ID = P002O2_A26TrActividades_ID[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (String)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
      }

      protected void S121( )
      {
         /* 'ACTUALIZARACTIVIDAD' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P002O3 */
         pr_default.execute(1, new Object[] {n33TrActividades_Estado, AV8GestionActividades_SDT.gxTpr_Tractividades_estado, n30TrActividades_FechaFin, AV8GestionActividades_SDT.gxTpr_Tractividades_fechafin, n29TrActividades_FechaInicio, AV8GestionActividades_SDT.gxTpr_Tractividades_fechainicio, n28TrActividades_Descripcion, AV8GestionActividades_SDT.gxTpr_Tractividades_descripcion, n27TrActividades_Nombre, AV8GestionActividades_SDT.gxTpr_Tractividades_nombre, AV8GestionActividades_SDT.gxTpr_Tractividades_id, AV8GestionActividades_SDT.gxTpr_Tractividades_idtarea});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TrActividades") ;
         /* End optimized UPDATE. */
      }

      protected void S131( )
      {
         /* 'AGREGARACTIVIDAD' Routine */
         /*
            INSERT RECORD ON TABLE TrActividadesLevel1

         */
         A26TrActividades_ID = AV8GestionActividades_SDT.gxTpr_Tractividades_id;
         A56TrListaActividad_Nombre = AV8GestionActividades_SDT.gxTpr_Trlistaactividad_nombre;
         n56TrListaActividad_Nombre = false;
         A57TrListaActividad_Descripcion = AV8GestionActividades_SDT.gxTpr_Trlistaactividad_descripcion;
         n57TrListaActividad_Descripcion = false;
         A58TrListaActividad_FechaInicio = AV8GestionActividades_SDT.gxTpr_Trlistaactividad_fechainicio;
         n58TrListaActividad_FechaInicio = false;
         A59TrListaActividad_FechaFin = AV8GestionActividades_SDT.gxTpr_Trlistaactividad_fechafin;
         n59TrListaActividad_FechaFin = false;
         A60TrListaActividad_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n60TrListaActividad_FechaCreacion = false;
         A62TrListaActividad_Estado = AV8GestionActividades_SDT.gxTpr_Trlistaactividad_estado;
         n62TrListaActividad_Estado = false;
         A55TrListaActividad_ID = (Guid)(Guid.NewGuid( ));
         /* Using cursor P002O4 */
         pr_default.execute(2, new Object[] {A26TrActividades_ID, n56TrListaActividad_Nombre, A56TrListaActividad_Nombre, n57TrListaActividad_Descripcion, A57TrListaActividad_Descripcion, n58TrListaActividad_FechaInicio, A58TrListaActividad_FechaInicio, n59TrListaActividad_FechaFin, A59TrListaActividad_FechaFin, n60TrListaActividad_FechaCreacion, A60TrListaActividad_FechaCreacion, n62TrListaActividad_Estado, A62TrListaActividad_Estado, A55TrListaActividad_ID});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
         if ( (pr_default.getStatus(2) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (String)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
      }

      protected void S141( )
      {
         /* 'ELIMINARLISTAACTIVIDAD' Routine */
         /* Optimized DELETE. */
         /* Using cursor P002O5 */
         pr_default.execute(3, new Object[] {AV8GestionActividades_SDT.gxTpr_Tractividades_id, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_id});
         pr_default.close(3);
         dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
         /* End optimized DELETE. */
      }

      protected void S151( )
      {
         /* 'ACTUALIZARLISTAACTIVIDAD' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P002O6 */
         pr_default.execute(4, new Object[] {n62TrListaActividad_Estado, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_estado, n59TrListaActividad_FechaFin, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_fechafin, n58TrListaActividad_FechaInicio, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_fechainicio, n57TrListaActividad_Descripcion, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_descripcion, n56TrListaActividad_Nombre, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_nombre, AV8GestionActividades_SDT.gxTpr_Tractividades_id, AV8GestionActividades_SDT.gxTpr_Trlistaactividad_id});
         pr_default.close(4);
         dsDefault.SmartCacheProvider.SetUpdated("TrActividadesLevel1") ;
         /* End optimized UPDATE. */
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         A27TrActividades_Nombre = "";
         A28TrActividades_Descripcion = "";
         A29TrActividades_FechaInicio = DateTime.MinValue;
         A30TrActividades_FechaFin = DateTime.MinValue;
         A31TrActividades_FechaCreacion = DateTime.MinValue;
         P002O2_A26TrActividades_ID = new long[1] ;
         Gx_emsg = "";
         A56TrListaActividad_Nombre = "";
         A57TrListaActividad_Descripcion = "";
         A58TrListaActividad_FechaInicio = DateTime.MinValue;
         A59TrListaActividad_FechaFin = DateTime.MinValue;
         A60TrListaActividad_FechaCreacion = DateTime.MinValue;
         A55TrListaActividad_ID = (Guid)(Guid.Empty);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgestionaractividades__default(),
            new Object[][] {
                new Object[] {
               P002O2_A26TrActividades_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A33TrActividades_Estado ;
      private short A62TrListaActividad_Estado ;
      private int GX_INS4 ;
      private int GX_INS9 ;
      private long A25TrActividades_IDTarea ;
      private long A26TrActividades_ID ;
      private String AV10Modo ;
      private String A27TrActividades_Nombre ;
      private String Gx_emsg ;
      private String A56TrListaActividad_Nombre ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A31TrActividades_FechaCreacion ;
      private DateTime A58TrListaActividad_FechaInicio ;
      private DateTime A59TrListaActividad_FechaFin ;
      private DateTime A60TrListaActividad_FechaCreacion ;
      private bool returnInSub ;
      private bool n25TrActividades_IDTarea ;
      private bool n27TrActividades_Nombre ;
      private bool n28TrActividades_Descripcion ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n31TrActividades_FechaCreacion ;
      private bool n33TrActividades_Estado ;
      private bool n56TrListaActividad_Nombre ;
      private bool n57TrListaActividad_Descripcion ;
      private bool n58TrListaActividad_FechaInicio ;
      private bool n59TrListaActividad_FechaFin ;
      private bool n60TrListaActividad_FechaCreacion ;
      private bool n62TrListaActividad_Estado ;
      private String A28TrActividades_Descripcion ;
      private String A57TrListaActividad_Descripcion ;
      private Guid A55TrListaActividad_ID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002O2_A26TrActividades_ID ;
      private SdtGestionActividades_SDT AV8GestionActividades_SDT ;
   }

   public class prgestionaractividades__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002O2 ;
          prmP002O2 = new Object[] {
          new Object[] {"@TrActividades_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrActividades_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_Estado",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmP002O3 ;
          prmP002O3 = new Object[] {
          new Object[] {"@TrActividades_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrActividades_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV8Gesti_1Tractividades_id",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV8Gesti_2Tractividades_idtar",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmP002O4 ;
          prmP002O4 = new Object[] {
          new Object[] {"@TrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrListaActividad_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrListaActividad_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrListaActividad_ID",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmP002O5 ;
          prmP002O5 = new Object[] {
          new Object[] {"@AV8Gesti_1Tractividades_id",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV8Gesti_3Trlistaactividad_id",SqlDbType.UniqueIdentifier,13,0}
          } ;
          Object[] prmP002O6 ;
          prmP002O6 = new Object[] {
          new Object[] {"@TrListaActividad_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrListaActividad_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrListaActividad_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrListaActividad_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV8Gesti_1Tractividades_id",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV8Gesti_3Trlistaactividad_id",SqlDbType.UniqueIdentifier,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P002O2", "INSERT INTO TABLERO.[TrActividades]([TrActividades_IDTarea], [TrActividades_Nombre], [TrActividades_Descripcion], [TrActividades_FechaInicio], [TrActividades_FechaFin], [TrActividades_FechaCreacion], [TrActividades_Estado], [TrActividades_FechaModificacion]) VALUES(@TrActividades_IDTarea, @TrActividades_Nombre, @TrActividades_Descripcion, @TrActividades_FechaInicio, @TrActividades_FechaFin, @TrActividades_FechaCreacion, @TrActividades_Estado, convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP002O2)
             ,new CursorDef("P002O3", "UPDATE TABLERO.[TrActividades] SET [TrActividades_Estado]=@TrActividades_Estado, [TrActividades_FechaModificacion]=GETUTCDATE(), [TrActividades_FechaFin]=@TrActividades_FechaFin, [TrActividades_FechaInicio]=@TrActividades_FechaInicio, [TrActividades_Descripcion]=@TrActividades_Descripcion, [TrActividades_Nombre]=@TrActividades_Nombre  WHERE ([TrActividades_ID] = @AV8Gesti_1Tractividades_id) AND ([TrActividades_IDTarea] = @AV8Gesti_2Tractividades_idtar)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002O3)
             ,new CursorDef("P002O4", "INSERT INTO TABLERO.[TrActividadesLevel1]([TrActividades_ID], [TrListaActividad_Nombre], [TrListaActividad_Descripcion], [TrListaActividad_FechaInicio], [TrListaActividad_FechaFin], [TrListaActividad_FechaCreacion], [TrListaActividad_Estado], [TrListaActividad_ID], [TrListaActividad_FechaModificacion]) VALUES(@TrActividades_ID, @TrListaActividad_Nombre, @TrListaActividad_Descripcion, @TrListaActividad_FechaInicio, @TrListaActividad_FechaFin, @TrListaActividad_FechaCreacion, @TrListaActividad_Estado, @TrListaActividad_ID, convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP002O4)
             ,new CursorDef("P002O5", "DELETE FROM TABLERO.[TrActividadesLevel1]  WHERE [TrActividades_ID] = @AV8Gesti_1Tractividades_id and [TrListaActividad_ID] = @AV8Gesti_3Trlistaactividad_id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002O5)
             ,new CursorDef("P002O6", "UPDATE TABLERO.[TrActividadesLevel1] SET [TrListaActividad_Estado]=@TrListaActividad_Estado, [TrListaActividad_FechaModificacion]=GETUTCDATE(), [TrListaActividad_FechaFin]=@TrListaActividad_FechaFin, [TrListaActividad_FechaInicio]=@TrListaActividad_FechaInicio, [TrListaActividad_Descripcion]=@TrListaActividad_Descripcion, [TrListaActividad_Nombre]=@TrListaActividad_Nombre  WHERE [TrActividades_ID] = @AV8Gesti_1Tractividades_id and [TrListaActividad_ID] = @AV8Gesti_3Trlistaactividad_id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002O6)
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
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[13]);
                }
                return;
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(5, (String)parms[9]);
                }
                stmt.SetParameter(6, (long)parms[10]);
                stmt.SetParameter(7, (long)parms[11]);
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[2]);
                }
                if ( (bool)parms[3] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[4]);
                }
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[8]);
                }
                if ( (bool)parms[9] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[12]);
                }
                stmt.SetParameter(8, (Guid)parms[13]);
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (Guid)parms[1]);
                return;
             case 4 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(5, (String)parms[9]);
                }
                stmt.SetParameter(6, (long)parms[10]);
                stmt.SetParameter(7, (Guid)parms[11]);
                return;
       }
    }

 }

}
