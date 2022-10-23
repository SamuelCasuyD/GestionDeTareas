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
   public class tpcreartablero : GXProcedure
   {
      public tpcreartablero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public tpcreartablero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( SdtCrearTablero_SDT aP0_CrearTablero_SDT ,
                           String aP1_Modo )
      {
         this.AV8CrearTablero_SDT = aP0_CrearTablero_SDT;
         this.AV18Modo = aP1_Modo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtCrearTablero_SDT aP0_CrearTablero_SDT ,
                                 String aP1_Modo )
      {
         tpcreartablero objtpcreartablero;
         objtpcreartablero = new tpcreartablero();
         objtpcreartablero.AV8CrearTablero_SDT = aP0_CrearTablero_SDT;
         objtpcreartablero.AV18Modo = aP1_Modo;
         objtpcreartablero.context.SetSubmitInitialConfig(context);
         objtpcreartablero.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtpcreartablero);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tpcreartablero)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV18Modo, "INS") == 0 )
         {
            /* Execute user subroutine: 'NUEVOTABLERO' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tablero creado");
         }
         else if ( StringUtil.StrCmp(AV18Modo, "UDP") == 0 )
         {
            /* Execute user subroutine: 'ACTUALIZARTABLERO' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tablero actualizado");
         }
         else if ( StringUtil.StrCmp(AV18Modo, "DEL") == 0 )
         {
            /* Execute user subroutine: 'ELIMINARTABLERO' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tablero eliminado");
         }
         context.CommitDataStores("tpcreartablero",pr_default);
         this.cleanup();
         if (true) return;
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NUEVOTABLERO' Routine */
         AV9GUID = (Guid)(Guid.NewGuid( ));
         /*
            INSERT RECORD ON TABLE TrGestionTableros

         */
         A1TrGestionTableros_ID = (Guid)(AV9GUID);
         A2TrGestionTableros_Nombre = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_nombre;
         n2TrGestionTableros_Nombre = false;
         A5TrGestionTableros_Descripcion = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_descripcion;
         n5TrGestionTableros_Descripcion = false;
         A6TrGestionTableros_Comentario = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_comentario;
         n6TrGestionTableros_Comentario = false;
         A9TrGestionTableros_TipoTablero = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_tipotablero;
         n9TrGestionTableros_TipoTablero = false;
         A3TrGestionTableros_FechaInicio = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_fechainicio;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = AV8CrearTablero_SDT.gxTpr_Trgestiontableros_fechafin;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n7TrGestionTableros_FechaCreacion = false;
         A10TrGestionTableros_Estado = 1;
         n10TrGestionTableros_Estado = false;
         /* Using cursor P002L2 */
         pr_default.execute(0, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
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
         /* 'ACTUALIZARTABLERO' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P002L3 */
         pr_default.execute(1, new Object[] {n10TrGestionTableros_Estado, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_estado, n4TrGestionTableros_FechaFin, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_fechafin, n3TrGestionTableros_FechaInicio, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_fechainicio, n9TrGestionTableros_TipoTablero, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_tipotablero, n6TrGestionTableros_Comentario, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_comentario, n5TrGestionTableros_Descripcion, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_descripcion, n2TrGestionTableros_Nombre, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_nombre, AV8CrearTablero_SDT.gxTpr_Trgestiontableros_id});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
         /* End optimized UPDATE. */
      }

      protected void S131( )
      {
         /* 'ELIMINARTABLERO' Routine */
         AV23GXLvl56 = 0;
         /* Using cursor P002L4 */
         pr_default.execute(2, new Object[] {AV8CrearTablero_SDT.gxTpr_Trgestiontableros_id});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11TrGestionTareas_IDTablero = (Guid)((Guid)(P002L4_A11TrGestionTareas_IDTablero[0]));
            A12TrGestionTareas_ID = P002L4_A12TrGestionTareas_ID[0];
            AV23GXLvl56 = 1;
            AV19Existe = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV23GXLvl56 == 0 )
         {
            AV19Existe = false;
         }
         if ( ! AV19Existe )
         {
            /* Optimized DELETE. */
            /* Using cursor P002L5 */
            pr_default.execute(3, new Object[] {AV8CrearTablero_SDT.gxTpr_Trgestiontableros_id});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
            /* End optimized DELETE. */
         }
         else
         {
            GX_msglist.addItem("El tablero no puede eliminarse por que ya cuenta con tareas");
            returnInSub = true;
            if (true) return;
         }
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
         AV9GUID = (Guid)(Guid.Empty);
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A5TrGestionTableros_Descripcion = "";
         A6TrGestionTableros_Comentario = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Gx_emsg = "";
         scmdbuf = "";
         P002L4_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         P002L4_A12TrGestionTareas_ID = new long[1] ;
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tpcreartablero__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P002L4_A11TrGestionTareas_IDTablero, P002L4_A12TrGestionTareas_ID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A9TrGestionTableros_TipoTablero ;
      private short A10TrGestionTableros_Estado ;
      private short AV23GXLvl56 ;
      private int GX_INS1 ;
      private long A12TrGestionTareas_ID ;
      private String AV18Modo ;
      private String A2TrGestionTableros_Nombre ;
      private String Gx_emsg ;
      private String scmdbuf ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private bool returnInSub ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n10TrGestionTableros_Estado ;
      private bool AV19Existe ;
      private String A5TrGestionTableros_Descripcion ;
      private String A6TrGestionTableros_Comentario ;
      private Guid AV9GUID ;
      private Guid A1TrGestionTableros_ID ;
      private Guid A11TrGestionTareas_IDTablero ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P002L4_A11TrGestionTareas_IDTablero ;
      private long[] P002L4_A12TrGestionTareas_ID ;
      private SdtCrearTablero_SDT AV8CrearTablero_SDT ;
   }

   public class tpcreartablero__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002L2 ;
          prmP002L2 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmP002L3 ;
          prmP002L3 = new Object[] {
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV8Crear_1Trgestiontableros_i",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP002L4 ;
          prmP002L4 = new Object[] {
          new Object[] {"@AV8Crear_1Trgestiontableros_i",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP002L5 ;
          prmP002L5 = new Object[] {
          new Object[] {"@AV8Crear_1Trgestiontableros_i",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P002L2", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_Estado], [TrGestionTableros_FechaModificacion]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, @TrGestionTableros_TipoTablero, @TrGestionTableros_Estado, convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP002L2)
             ,new CursorDef("P002L3", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_Estado]=@TrGestionTableros_Estado, [TrGestionTableros_FechaModificacion]=GETUTCDATE(), [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_TipoTablero]=@TrGestionTableros_TipoTablero, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre  WHERE [TrGestionTableros_ID] = @AV8Crear_1Trgestiontableros_i", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002L3)
             ,new CursorDef("P002L4", "SELECT [TrGestionTareas_IDTablero], [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_IDTablero] = @AV8Crear_1Trgestiontableros_i ORDER BY [TrGestionTareas_IDTablero] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002L4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002L5", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @AV8Crear_1Trgestiontableros_i", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002L5)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
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
                stmt.SetParameter(1, (Guid)parms[0]);
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
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[4]);
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
                   stmt.setNull( 6 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(6, (String)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 7 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 8 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(8, (short)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 9 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(9, (short)parms[16]);
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
                   stmt.setNull( 4 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(4, (short)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(5, (String)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(6, (String)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[13]);
                }
                stmt.SetParameter(8, (Guid)parms[14]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
