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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trgestiontableros_bc : GXHttpHandler, IGxSilentTrn
   {
      public trgestiontableros_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public trgestiontableros_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
               SetMode( "UPD") ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
         }
         if ( GX_JID == -6 )
         {
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z6TrGestionTableros_Comentario = A6TrGestionTableros_Comentario;
            Z5TrGestionTableros_Descripcion = A5TrGestionTableros_Descripcion;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2TrGestionTableros_Nombre = BC00014_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00014_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00014_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00014_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00014_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00014_n5TrGestionTableros_Descripcion[0];
            A3TrGestionTableros_FechaInicio = BC00014_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00014_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00014_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00014_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00014_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00014_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00014_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00014_n8TrGestionTableros_FechaModificacion[0];
            ZM011( -6) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A3TrGestionTableros_FechaInicio) || ( A3TrGestionTableros_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Inicio is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A4TrGestionTableros_FechaFin) || ( A4TrGestionTableros_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Fin is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A7TrGestionTableros_FechaCreacion) || ( A7TrGestionTableros_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Creacion is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A8TrGestionTableros_FechaModificacion) || ( A8TrGestionTableros_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Gestion Tableros_Fecha Modificacion is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 6) ;
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC00013_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC00013_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00013_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00013_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00013_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00013_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00013_n5TrGestionTableros_Descripcion[0];
            A3TrGestionTableros_FechaInicio = BC00013_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00013_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00013_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00013_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00013_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00013_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00013_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00013_n8TrGestionTableros_FechaModificacion[0];
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, BC00012_A2TrGestionTableros_Nombre[0]) != 0 ) || ( Z3TrGestionTableros_FechaInicio != BC00012_A3TrGestionTableros_FechaInicio[0] ) || ( Z4TrGestionTableros_FechaFin != BC00012_A4TrGestionTableros_FechaFin[0] ) || ( Z7TrGestionTableros_FechaCreacion != BC00012_A7TrGestionTableros_FechaCreacion[0] ) || ( Z8TrGestionTableros_FechaModificacion != BC00012_A8TrGestionTableros_FechaModificacion[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrGestionTableros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, A1TrGestionTableros_ID});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00018 */
                  pr_default.execute(6, new Object[] {A1TrGestionTableros_ID});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Using cursor BC00019 */
         pr_default.execute(7, new Object[] {A1TrGestionTableros_ID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC00019_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC00019_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00019_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00019_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00019_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00019_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00019_n5TrGestionTableros_Descripcion[0];
            A3TrGestionTableros_FechaInicio = BC00019_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00019_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00019_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00019_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00019_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00019_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00019_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00019_n8TrGestionTableros_FechaModificacion[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC00019_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC00019_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00019_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00019_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00019_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00019_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00019_n5TrGestionTableros_Descripcion[0];
            A3TrGestionTableros_FechaInicio = BC00019_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00019_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00019_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00019_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00019_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00019_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00019_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00019_n8TrGestionTableros_FechaModificacion[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcTrGestionTableros) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcTrGestionTableros, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2TrGestionTableros_Nombre = "";
         n2TrGestionTableros_Nombre = false;
         A6TrGestionTableros_Comentario = "";
         n6TrGestionTableros_Comentario = false;
         A5TrGestionTableros_Descripcion = "";
         n5TrGestionTableros_Descripcion = false;
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         n7TrGestionTableros_FechaCreacion = false;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         n8TrGestionTableros_FechaModificacion = false;
         Z2TrGestionTableros_Nombre = "";
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
      }

      protected void InitAll011( )
      {
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtTrGestionTableros obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Trgestiontableros_nombre = A2TrGestionTableros_Nombre;
         obj1.gxTpr_Trgestiontableros_comentario = A6TrGestionTableros_Comentario;
         obj1.gxTpr_Trgestiontableros_descripcion = A5TrGestionTableros_Descripcion;
         obj1.gxTpr_Trgestiontableros_fechainicio = A3TrGestionTableros_FechaInicio;
         obj1.gxTpr_Trgestiontableros_fechafin = A4TrGestionTableros_FechaFin;
         obj1.gxTpr_Trgestiontableros_fechacreacion = A7TrGestionTableros_FechaCreacion;
         obj1.gxTpr_Trgestiontableros_fechamodificacion = A8TrGestionTableros_FechaModificacion;
         obj1.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
         obj1.gxTpr_Trgestiontableros_id_Z = (Guid)(Z1TrGestionTableros_ID);
         obj1.gxTpr_Trgestiontableros_nombre_Z = Z2TrGestionTableros_Nombre;
         obj1.gxTpr_Trgestiontableros_fechainicio_Z = Z3TrGestionTableros_FechaInicio;
         obj1.gxTpr_Trgestiontableros_fechafin_Z = Z4TrGestionTableros_FechaFin;
         obj1.gxTpr_Trgestiontableros_fechacreacion_Z = Z7TrGestionTableros_FechaCreacion;
         obj1.gxTpr_Trgestiontableros_fechamodificacion_Z = Z8TrGestionTableros_FechaModificacion;
         obj1.gxTpr_Trgestiontableros_nombre_N = (short)(Convert.ToInt16(n2TrGestionTableros_Nombre));
         obj1.gxTpr_Trgestiontableros_comentario_N = (short)(Convert.ToInt16(n6TrGestionTableros_Comentario));
         obj1.gxTpr_Trgestiontableros_descripcion_N = (short)(Convert.ToInt16(n5TrGestionTableros_Descripcion));
         obj1.gxTpr_Trgestiontableros_fechainicio_N = (short)(Convert.ToInt16(n3TrGestionTableros_FechaInicio));
         obj1.gxTpr_Trgestiontableros_fechafin_N = (short)(Convert.ToInt16(n4TrGestionTableros_FechaFin));
         obj1.gxTpr_Trgestiontableros_fechacreacion_N = (short)(Convert.ToInt16(n7TrGestionTableros_FechaCreacion));
         obj1.gxTpr_Trgestiontableros_fechamodificacion_N = (short)(Convert.ToInt16(n8TrGestionTableros_FechaModificacion));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtTrGestionTableros obj1 )
      {
         obj1.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
         return  ;
      }

      public void RowToVars1( SdtTrGestionTableros obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2TrGestionTableros_Nombre = obj1.gxTpr_Trgestiontableros_nombre;
         n2TrGestionTableros_Nombre = false;
         A6TrGestionTableros_Comentario = obj1.gxTpr_Trgestiontableros_comentario;
         n6TrGestionTableros_Comentario = false;
         A5TrGestionTableros_Descripcion = obj1.gxTpr_Trgestiontableros_descripcion;
         n5TrGestionTableros_Descripcion = false;
         A3TrGestionTableros_FechaInicio = obj1.gxTpr_Trgestiontableros_fechainicio;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = obj1.gxTpr_Trgestiontableros_fechafin;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = obj1.gxTpr_Trgestiontableros_fechacreacion;
         n7TrGestionTableros_FechaCreacion = false;
         A8TrGestionTableros_FechaModificacion = obj1.gxTpr_Trgestiontableros_fechamodificacion;
         n8TrGestionTableros_FechaModificacion = false;
         A1TrGestionTableros_ID = (Guid)(obj1.gxTpr_Trgestiontableros_id);
         Z1TrGestionTableros_ID = (Guid)(obj1.gxTpr_Trgestiontableros_id_Z);
         Z2TrGestionTableros_Nombre = obj1.gxTpr_Trgestiontableros_nombre_Z;
         Z3TrGestionTableros_FechaInicio = obj1.gxTpr_Trgestiontableros_fechainicio_Z;
         Z4TrGestionTableros_FechaFin = obj1.gxTpr_Trgestiontableros_fechafin_Z;
         Z7TrGestionTableros_FechaCreacion = obj1.gxTpr_Trgestiontableros_fechacreacion_Z;
         Z8TrGestionTableros_FechaModificacion = obj1.gxTpr_Trgestiontableros_fechamodificacion_Z;
         n2TrGestionTableros_Nombre = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_nombre_N));
         n6TrGestionTableros_Comentario = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_comentario_N));
         n5TrGestionTableros_Descripcion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_descripcion_N));
         n3TrGestionTableros_FechaInicio = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechainicio_N));
         n4TrGestionTableros_FechaFin = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechafin_N));
         n7TrGestionTableros_FechaCreacion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechacreacion_N));
         n8TrGestionTableros_FechaModificacion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechamodificacion_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1TrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
         }
         ZM011( -6) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcTrGestionTableros, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
         }
         ZM011( -6) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         SaveImpl( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtTrGestionTableros auxBC = new SdtTrGestionTableros(context) ;
            IGxSilentTrn auxTrn = auxBC.getTransaction() ;
            auxBC.Load(A1TrGestionTableros_ID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrGestionTableros);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         UpdateImpl( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcTrGestionTableros, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
            {
               A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("trgestiontableros_bc",pr_default);
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public String GetMode( )
      {
         Gx_mode = bcTrGestionTableros.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( String lMode )
      {
         Gx_mode = lMode;
         bcTrGestionTableros.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrGestionTableros )
         {
            bcTrGestionTableros = (SdtTrGestionTableros)(sdt);
            if ( StringUtil.StrCmp(bcTrGestionTableros.gxTpr_Mode, "") == 0 )
            {
               bcTrGestionTableros.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcTrGestionTableros) ;
            }
            else
            {
               RowToVars1( bcTrGestionTableros, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrGestionTableros.gxTpr_Mode, "") == 0 )
            {
               bcTrGestionTableros.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcTrGestionTableros, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTrGestionTableros TrGestionTableros_BC
      {
         get {
            return bcTrGestionTableros ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         Z1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         Z2TrGestionTableros_Nombre = "";
         A2TrGestionTableros_Nombre = "";
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         Z6TrGestionTableros_Comentario = "";
         A6TrGestionTableros_Comentario = "";
         Z5TrGestionTableros_Descripcion = "";
         A5TrGestionTableros_Descripcion = "";
         BC00014_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00014_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00014_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00014_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00014_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00014_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00014_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00014_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00014_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00014_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00014_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00014_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00014_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00014_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00014_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC00015_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00013_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00013_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00013_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00013_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00013_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00013_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00013_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00013_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00013_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00013_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00013_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00013_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00013_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00013_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00013_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         sMode1 = "";
         BC00012_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00012_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00012_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00012_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00012_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00012_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00012_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00012_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00012_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00012_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00012_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00012_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00012_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00012_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00012_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC00019_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00019_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00019_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00019_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00019_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00019_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00019_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00019_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00019_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00019_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00019_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00019_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00019_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00019_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00019_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontableros_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1TrGestionTableros_ID, BC00012_A2TrGestionTableros_Nombre, BC00012_n2TrGestionTableros_Nombre, BC00012_A6TrGestionTableros_Comentario, BC00012_n6TrGestionTableros_Comentario, BC00012_A5TrGestionTableros_Descripcion, BC00012_n5TrGestionTableros_Descripcion, BC00012_A3TrGestionTableros_FechaInicio, BC00012_n3TrGestionTableros_FechaInicio, BC00012_A4TrGestionTableros_FechaFin,
               BC00012_n4TrGestionTableros_FechaFin, BC00012_A7TrGestionTableros_FechaCreacion, BC00012_n7TrGestionTableros_FechaCreacion, BC00012_A8TrGestionTableros_FechaModificacion, BC00012_n8TrGestionTableros_FechaModificacion
               }
               , new Object[] {
               BC00013_A1TrGestionTableros_ID, BC00013_A2TrGestionTableros_Nombre, BC00013_n2TrGestionTableros_Nombre, BC00013_A6TrGestionTableros_Comentario, BC00013_n6TrGestionTableros_Comentario, BC00013_A5TrGestionTableros_Descripcion, BC00013_n5TrGestionTableros_Descripcion, BC00013_A3TrGestionTableros_FechaInicio, BC00013_n3TrGestionTableros_FechaInicio, BC00013_A4TrGestionTableros_FechaFin,
               BC00013_n4TrGestionTableros_FechaFin, BC00013_A7TrGestionTableros_FechaCreacion, BC00013_n7TrGestionTableros_FechaCreacion, BC00013_A8TrGestionTableros_FechaModificacion, BC00013_n8TrGestionTableros_FechaModificacion
               }
               , new Object[] {
               BC00014_A1TrGestionTableros_ID, BC00014_A2TrGestionTableros_Nombre, BC00014_n2TrGestionTableros_Nombre, BC00014_A6TrGestionTableros_Comentario, BC00014_n6TrGestionTableros_Comentario, BC00014_A5TrGestionTableros_Descripcion, BC00014_n5TrGestionTableros_Descripcion, BC00014_A3TrGestionTableros_FechaInicio, BC00014_n3TrGestionTableros_FechaInicio, BC00014_A4TrGestionTableros_FechaFin,
               BC00014_n4TrGestionTableros_FechaFin, BC00014_A7TrGestionTableros_FechaCreacion, BC00014_n7TrGestionTableros_FechaCreacion, BC00014_A8TrGestionTableros_FechaModificacion, BC00014_n8TrGestionTableros_FechaModificacion
               }
               , new Object[] {
               BC00015_A1TrGestionTableros_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00019_A1TrGestionTableros_ID, BC00019_A2TrGestionTableros_Nombre, BC00019_n2TrGestionTableros_Nombre, BC00019_A6TrGestionTableros_Comentario, BC00019_n6TrGestionTableros_Comentario, BC00019_A5TrGestionTableros_Descripcion, BC00019_n5TrGestionTableros_Descripcion, BC00019_A3TrGestionTableros_FechaInicio, BC00019_n3TrGestionTableros_FechaInicio, BC00019_A4TrGestionTableros_FechaFin,
               BC00019_n4TrGestionTableros_FechaFin, BC00019_A7TrGestionTableros_FechaCreacion, BC00019_n7TrGestionTableros_FechaCreacion, BC00019_A8TrGestionTableros_FechaModificacion, BC00019_n8TrGestionTableros_FechaModificacion
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private String scmdbuf ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String Gx_mode ;
      private String Z2TrGestionTableros_Nombre ;
      private String A2TrGestionTableros_Nombre ;
      private String sMode1 ;
      private DateTime Z3TrGestionTableros_FechaInicio ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime Z4TrGestionTableros_FechaFin ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime Z7TrGestionTableros_FechaCreacion ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime Z8TrGestionTableros_FechaModificacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool mustCommit ;
      private String Z6TrGestionTableros_Comentario ;
      private String A6TrGestionTableros_Comentario ;
      private String Z5TrGestionTableros_Descripcion ;
      private String A5TrGestionTableros_Descripcion ;
      private Guid Z1TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private SdtTrGestionTableros bcTrGestionTableros ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00014_A1TrGestionTableros_ID ;
      private String[] BC00014_A2TrGestionTableros_Nombre ;
      private bool[] BC00014_n2TrGestionTableros_Nombre ;
      private String[] BC00014_A6TrGestionTableros_Comentario ;
      private bool[] BC00014_n6TrGestionTableros_Comentario ;
      private String[] BC00014_A5TrGestionTableros_Descripcion ;
      private bool[] BC00014_n5TrGestionTableros_Descripcion ;
      private DateTime[] BC00014_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00014_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00014_A4TrGestionTableros_FechaFin ;
      private bool[] BC00014_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00014_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00014_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00014_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00014_n8TrGestionTableros_FechaModificacion ;
      private Guid[] BC00015_A1TrGestionTableros_ID ;
      private Guid[] BC00013_A1TrGestionTableros_ID ;
      private String[] BC00013_A2TrGestionTableros_Nombre ;
      private bool[] BC00013_n2TrGestionTableros_Nombre ;
      private String[] BC00013_A6TrGestionTableros_Comentario ;
      private bool[] BC00013_n6TrGestionTableros_Comentario ;
      private String[] BC00013_A5TrGestionTableros_Descripcion ;
      private bool[] BC00013_n5TrGestionTableros_Descripcion ;
      private DateTime[] BC00013_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00013_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00013_A4TrGestionTableros_FechaFin ;
      private bool[] BC00013_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00013_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00013_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00013_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00013_n8TrGestionTableros_FechaModificacion ;
      private Guid[] BC00012_A1TrGestionTableros_ID ;
      private String[] BC00012_A2TrGestionTableros_Nombre ;
      private bool[] BC00012_n2TrGestionTableros_Nombre ;
      private String[] BC00012_A6TrGestionTableros_Comentario ;
      private bool[] BC00012_n6TrGestionTableros_Comentario ;
      private String[] BC00012_A5TrGestionTableros_Descripcion ;
      private bool[] BC00012_n5TrGestionTableros_Descripcion ;
      private DateTime[] BC00012_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00012_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00012_A4TrGestionTableros_FechaFin ;
      private bool[] BC00012_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00012_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00012_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00012_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00012_n8TrGestionTableros_FechaModificacion ;
      private Guid[] BC00019_A1TrGestionTableros_ID ;
      private String[] BC00019_A2TrGestionTableros_Nombre ;
      private bool[] BC00019_n2TrGestionTableros_Nombre ;
      private String[] BC00019_A6TrGestionTableros_Comentario ;
      private bool[] BC00019_n6TrGestionTableros_Comentario ;
      private String[] BC00019_A5TrGestionTableros_Descripcion ;
      private bool[] BC00019_n5TrGestionTableros_Descripcion ;
      private DateTime[] BC00019_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00019_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00019_A4TrGestionTableros_FechaFin ;
      private bool[] BC00019_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00019_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00019_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00019_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00019_n8TrGestionTableros_FechaModificacion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trgestiontableros_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00014 ;
          prmBC00014 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00015 ;
          prmBC00015 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00013 ;
          prmBC00013 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00012 ;
          prmBC00012 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00016 ;
          prmBC00016 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0}
          } ;
          Object[] prmBC00017 ;
          prmBC00017 = new Object[] {
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00018 ;
          prmBC00018 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00019 ;
          prmBC00019 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] WITH (UPDLOCK) WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_FechaModificacion)", GxErrorMask.GX_NOMASK,prmBC00016)
             ,new CursorDef("BC00017", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaCreacion]=@TrGestionTableros_FechaCreacion, [TrGestionTableros_FechaModificacion]=@TrGestionTableros_FechaModificacion  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmBC00017)
             ,new CursorDef("BC00018", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00019,100, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                return;
             case 1 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 4 :
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
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[4]);
                }
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[6]);
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
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[14]);
                }
                return;
             case 5 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.NVarChar );
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
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[13]);
                }
                stmt.SetParameter(8, (Guid)parms[14]);
                return;
             case 6 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
