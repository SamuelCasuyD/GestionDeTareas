using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateTrGestionTareas( )
      {
         String cmdBuffer = "" ;
         /* Indices for table TrGestionTareas */
         try
         {
            cmdBuffer=" CREATE TABLE TABLERO.[TrGestionTareas] ([TrGestionTareas_ID] decimal( 13) NOT NULL IDENTITY(1,1), [TrGestionTareas_IDTablero] uniqueidentifier NOT NULL , [TrGestionTareas_Nombre] nchar(100) NULL , [TrGestionTareas_Descripcion] NVARCHAR(MAX) NULL , [TrGestionTareas_FechaInicio] datetime NULL , [TrGestionTareas_FechaFin] datetime NULL , [TrGestionTareas_FechaCreacion] datetime NULL , [TrGestionTareas_FechaModificacion] datetime NULL , PRIMARY KEY([TrGestionTareas_ID]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               DropTableConstraints( "TABLERO.[TrGestionTareas]") ;
               cmdBuffer=" DROP TABLE TABLERO.[TrGestionTareas] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
               try
               {
                  DropTableConstraints( "TABLERO.[TrGestionTareas]") ;
                  cmdBuffer=" DROP VIEW TABLERO.[TrGestionTareas] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch ( Exception sqlex2 )
               {
                  try
                  {
                     DropTableConstraints( "TABLERO.[TrGestionTareas]") ;
                     cmdBuffer=" DROP FUNCTION TABLERO.[TrGestionTareas] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch ( Exception sqlex3 )
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TABLERO.[TrGestionTareas] ([TrGestionTareas_ID] decimal( 13) NOT NULL IDENTITY(1,1), [TrGestionTareas_IDTablero] uniqueidentifier NOT NULL , [TrGestionTareas_Nombre] nchar(100) NULL , [TrGestionTareas_Descripcion] NVARCHAR(MAX) NULL , [TrGestionTareas_FechaInicio] datetime NULL , [TrGestionTareas_FechaFin] datetime NULL , [TrGestionTareas_FechaCreacion] datetime NULL , [TrGestionTareas_FechaModificacion] datetime NULL , PRIMARY KEY([TrGestionTareas_ID]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRGESTIONTAREAS1] ON TABLERO.[TrGestionTareas] ([TrGestionTareas_IDTablero] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            cmdBuffer=" DROP INDEX [ITRGESTIONTAREAS1] ON TABLERO.[TrGestionTareas] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRGESTIONTAREAS1] ON TABLERO.[TrGestionTareas] ([TrGestionTareas_IDTablero] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrGestionTareasTrGestionTableros( )
      {
         String cmdBuffer ;
         try
         {
            cmdBuffer=" ALTER TABLE TABLERO.[TrGestionTareas] ADD CONSTRAINT [ITRGESTIONTAREAS1] FOREIGN KEY ([TrGestionTareas_IDTablero]) REFERENCES TABLERO.[TrGestionTableros] ([TrGestionTableros_ID]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch ( Exception ex )
         {
            try
            {
               cmdBuffer=" ALTER TABLE TABLERO.[TrGestionTareas] DROP CONSTRAINT [ITRGESTIONTAREAS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch ( Exception sqlex1 )
            {
            }
            cmdBuffer=" ALTER TABLE TABLERO.[TrGestionTareas] ADD CONSTRAINT [ITRGESTIONTAREAS1] FOREIGN KEY ([TrGestionTareas_IDTablero]) REFERENCES TABLERO.[TrGestionTableros] ([TrGestionTableros_ID]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = "TABLERO";
         if ( tableexist("TrGestionTareas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TrGestionTareas"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( String sTableName ,
                               String sMySchemaName )
      {
         bool result ;
         result = false;
         /* Using cursor P00012 */
         pr_default.execute(0, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            tablename = P00012_Atablename[0];
            ntablename = P00012_ntablename[0];
            schemaname = P00012_Aschemaname[0];
            nschemaname = P00012_nschemaname[0];
            result = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateTrGestionTareas" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "RITrGestionTareasTrGestionTableros" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TrGestionTareas", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITRGESTIONTAREAS1]"}) );
         ReorgExecute.RegisterPrecedence( "RITrGestionTareasTrGestionTableros" ,  "CreateTrGestionTareas" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public void DropTableConstraints( String sTableName )
      {
         String cmdBuffer ;
         /* Using cursor P00023 */
         pr_default.execute(1, new Object[] {sTableName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            constid = P00023_Aconstid[0];
            nconstid = P00023_nconstid[0];
            fkeyid = P00023_Afkeyid[0];
            nfkeyid = P00023_nfkeyid[0];
            rkeyid = P00023_Arkeyid[0];
            nrkeyid = P00023_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "TABLERO." + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         scmdbuf = "";
         P00012_Atablename = new String[] {""} ;
         P00012_ntablename = new bool[] {false} ;
         P00012_Aschemaname = new String[] {""} ;
         P00012_nschemaname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00023_Aconstid = new String[] {""} ;
         P00023_nconstid = new bool[] {false} ;
         P00023_Afkeyid = new String[] {""} ;
         P00023_nfkeyid = new bool[] {false} ;
         P00023_Arkeyid = new int[1] ;
         P00023_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_Atablename, P00012_Aschemaname
               }
               , new Object[] {
               P00023_Aconstid, P00023_Afkeyid, P00023_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int rkeyid ;
      protected String sSchemaVar ;
      protected String sTableName ;
      protected String sMySchemaName ;
      protected String scmdbuf ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected String tablename ;
      protected String schemaname ;
      protected String constid ;
      protected String fkeyid ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected String[] P00012_Atablename ;
      protected bool[] P00012_ntablename ;
      protected String[] P00012_Aschemaname ;
      protected bool[] P00012_nschemaname ;
      protected String[] P00023_Aconstid ;
      protected bool[] P00023_nconstid ;
      protected String[] P00023_Afkeyid ;
      protected bool[] P00023_nfkeyid ;
      protected int[] P00023_Arkeyid ;
      protected bool[] P00023_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00012 ;
          prmP00012 = new Object[] {
          new Object[] {"@sTableName",SqlDbType.Char,255,0} ,
          new Object[] {"@sMySchemaName",SqlDbType.Char,255,0}
          } ;
          Object[] prmP00023 ;
          prmP00023 = new Object[] {
          new Object[] {"@sTableName",SqlDbType.Char,255,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                return;
             case 1 :
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
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
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                return;
             case 1 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
       }
    }

 }

}
