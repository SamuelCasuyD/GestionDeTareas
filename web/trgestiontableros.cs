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
   public class trgestiontableros : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetNextPar( );
               sSFPrefix = GetNextPar( );
               setjustcreated();
               componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
               }
               Form.Meta.addItem("description", "Nombre de tablero", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         GX_FocusControl = edtTrGestionTableros_ID_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public trgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
      }

      public trgestiontableros( IGxContext context )
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
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbTrGestionTableros_Estado = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbTrGestionTableros_Estado.ItemCount > 0 )
         {
            A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbTrGestionTableros_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0))), "."));
            n10TrGestionTableros_Estado = false;
            AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrGestionTableros_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0));
            AssignProp(sPrefix, false, cmbTrGestionTableros_Estado_Internalname, "Values", cmbTrGestionTableros_Estado.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
            RenderHtmlCloseForm011( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trgestiontableros.aspx");
            context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besmaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2beserrviewercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besdataareacontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2babstracttabledataareacontainer_Internalname, 1, 0, "px", 0, "px", "Table_DataAreaContainer Table_TransactionDataAreaContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2bentityservicesroottablecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2bentityservicesroottable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btabulardatacellcontainertrgestiontableros_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btabletabulardatatrgestiontableros_Internalname, 1, 0, "px", 0, "px", "Table_AttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_id_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_id_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_id_Internalname, "ID", "", "", lblTextblocktrgestiontableros_id_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_ID_Internalname, "ID gestión tablero", "col-sm-3 Attribute_TrnLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_ID_Internalname, A1TrGestionTableros_ID.ToString(), A1TrGestionTableros_ID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_ID_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTrGestionTableros_ID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_nombre_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_nombre_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_nombre_Internalname, "Nombre de Tablero", "", "", lblTextblocktrgestiontableros_nombre_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Nombre_Internalname, "Nombre del tablero", "col-sm-3 Attribute_TrnLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_Nombre_Internalname, StringUtil.RTrim( A2TrGestionTableros_Nombre), StringUtil.RTrim( context.localUtil.Format( A2TrGestionTableros_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_Nombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTrGestionTableros_Nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_comentario_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_comentario_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_comentario_Internalname, "Comentario", "", "", lblTextblocktrgestiontableros_comentario_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Comentario_Internalname, "Comentario", "col-sm-3 Attribute_TrnLabel", 0, true, "");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrGestionTableros_Comentario_Internalname, A6TrGestionTableros_Comentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, 1, edtTrGestionTableros_Comentario_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_descripcion_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_descripcion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_descripcion_Internalname, "Descripción", "", "", lblTextblocktrgestiontableros_descripcion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_Descripcion_Internalname, "Descripción", "col-sm-3 Attribute_TrnLabel", 0, true, "");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrGestionTableros_Descripcion_Internalname, A5TrGestionTableros_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtTrGestionTableros_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_tipotablero_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_tipotablero_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_tipotablero_Internalname, "Tipo de tablero", "", "", lblTextblocktrgestiontableros_tipotablero_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_TipoTablero_Internalname, "Tipo de tablero", "col-sm-3 Attribute_TrnLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_TipoTablero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")), ((edtTrGestionTableros_TipoTablero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9TrGestionTableros_TipoTablero), "ZZZ9")) : context.localUtil.Format( (decimal)(A9TrGestionTableros_TipoTablero), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_TipoTablero_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTrGestionTableros_TipoTablero_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_fechainicio_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_fechainicio_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_fechainicio_Internalname, "Fecha inicio", "", "", lblTextblocktrgestiontableros_fechainicio_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaInicio_Internalname, "Fecha Inicio", "col-sm-3 Attribute_TrnDateLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaInicio_Internalname, context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"), context.localUtil.Format( A3TrGestionTableros_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaInicio_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtTrGestionTableros_FechaInicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaInicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_fechafin_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_fechafin_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_fechafin_Internalname, "Fecha fin", "", "", lblTextblocktrgestiontableros_fechafin_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaFin_Internalname, "Fecha Fin", "col-sm-3 Attribute_TrnDateLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaFin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaFin_Internalname, context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"), context.localUtil.Format( A4TrGestionTableros_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaFin_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtTrGestionTableros_FechaFin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaFin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaFin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_fechacreacion_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_fechacreacion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_fechacreacion_Internalname, "Fecha de creacion", "", "", lblTextblocktrgestiontableros_fechacreacion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaCreacion_Internalname, "Fecha Creacion del tablero", "col-sm-3 Attribute_TrnDateLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaCreacion_Internalname, context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"), context.localUtil.Format( A7TrGestionTableros_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaCreacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtTrGestionTableros_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_fechamodificacion_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_fechamodificacion_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_fechamodificacion_Internalname, "Fecha de modificación", "", "", lblTextblocktrgestiontableros_fechamodificacion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrGestionTableros_FechaModificacion_Internalname, "Fecha Modificacion del tablero", "col-sm-3 Attribute_TrnDateLabel", 0, true, "");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrGestionTableros_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrGestionTableros_FechaModificacion_Internalname, context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"), context.localUtil.Format( A8TrGestionTableros_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrGestionTableros_FechaModificacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtTrGestionTableros_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrGestionTableros.htm");
         GxWebStd.gx_bitmap( context, edtTrGestionTableros_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrGestionTableros_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrGestionTableros.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabularcell_trgestiontableros_estado_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrgestiontableros_estado_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktrgestiontableros_estado_Internalname, "Estado", "", "", lblTextblocktrgestiontableros_estado_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, "HLP_TrGestionTableros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrGestionTableros_Estado_Internalname, "Estado del tablero", "col-sm-3 CheckBoxAttributeLabel", 0, true, "");
         AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrGestionTableros_Estado, cmbTrGestionTableros_Estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0)), 1, cmbTrGestionTableros_Estado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrGestionTableros_Estado.Enabled, 0, 0, 0, "em", 0, "", "", "CheckBoxAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "", true, "HLP_TrGestionTableros.htm");
         cmbTrGestionTableros_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         AssignProp(sPrefix, false, cmbTrGestionTableros_Estado_Internalname, "Values", (String)(cmbTrGestionTableros_Estado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besactioncontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblActionscontainerbuttons_Internalname, tblActionscontainerbuttons_Internalname, "", "Table_TrnActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", "Confirm", bttEnter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancel", bttCancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrGestionTableros.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2bescontrolbeaufitycell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"Z1TrGestionTableros_ID")));
               Z2TrGestionTableros_Nombre = cgiGet( sPrefix+"Z2TrGestionTableros_Nombre");
               n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
               Z9TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z9TrGestionTableros_TipoTablero"), ".", ","));
               n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
               Z3TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( sPrefix+"Z3TrGestionTableros_FechaInicio"), 0);
               n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
               Z4TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( sPrefix+"Z4TrGestionTableros_FechaFin"), 0);
               n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
               Z7TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( sPrefix+"Z7TrGestionTableros_FechaCreacion"), 0);
               n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
               Z8TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( sPrefix+"Z8TrGestionTableros_FechaModificacion"), 0);
               n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
               Z10TrGestionTableros_Estado = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z10TrGestionTableros_Estado"), ".", ","));
               n10TrGestionTableros_Estado = ((0==A10TrGestionTableros_Estado) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV7GUID = (Guid)(StringUtil.StrToGuid( cgiGet( sPrefix+"vGUID")));
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrGestionTableros_ID_Internalname), "") == 0 )
               {
                  A1TrGestionTableros_ID = (Guid)(Guid.Empty);
                  AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               }
               else
               {
                  try
                  {
                     A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTableros_ID_Internalname)));
                     AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
                  }
                  catch ( Exception e )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRGESTIONTABLEROS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A2TrGestionTableros_Nombre = cgiGet( edtTrGestionTableros_Nombre_Internalname);
               n2TrGestionTableros_Nombre = false;
               AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
               n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
               A6TrGestionTableros_Comentario = cgiGet( edtTrGestionTableros_Comentario_Internalname);
               n6TrGestionTableros_Comentario = false;
               AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
               n6TrGestionTableros_Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A6TrGestionTableros_Comentario)) ? true : false);
               A5TrGestionTableros_Descripcion = cgiGet( edtTrGestionTableros_Descripcion_Internalname);
               n5TrGestionTableros_Descripcion = false;
               AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
               n5TrGestionTableros_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A5TrGestionTableros_Descripcion)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRGESTIONTABLEROS_TIPOTABLERO");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_TipoTablero_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9TrGestionTableros_TipoTablero = 0;
                  n9TrGestionTableros_TipoTablero = false;
                  AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
               }
               else
               {
                  A9TrGestionTableros_TipoTablero = (short)(context.localUtil.CToN( cgiGet( edtTrGestionTableros_TipoTablero_Internalname), ".", ","));
                  n9TrGestionTableros_TipoTablero = false;
                  AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
               }
               n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Inicio"}), 1, "TRGESTIONTABLEROS_FECHAINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_FechaInicio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3TrGestionTableros_FechaInicio = DateTime.MinValue;
                  n3TrGestionTableros_FechaInicio = false;
                  AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
               }
               else
               {
                  A3TrGestionTableros_FechaInicio = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaInicio_Internalname), 1);
                  n3TrGestionTableros_FechaInicio = false;
                  AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
               }
               n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Fin"}), 1, "TRGESTIONTABLEROS_FECHAFIN");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_FechaFin_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4TrGestionTableros_FechaFin = DateTime.MinValue;
                  n4TrGestionTableros_FechaFin = false;
                  AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
               }
               else
               {
                  A4TrGestionTableros_FechaFin = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaFin_Internalname), 1);
                  n4TrGestionTableros_FechaFin = false;
                  AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
               }
               n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creacion del tablero"}), 1, "TRGESTIONTABLEROS_FECHACREACION");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_FechaCreacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
                  n7TrGestionTableros_FechaCreacion = false;
                  AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
               }
               else
               {
                  A7TrGestionTableros_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaCreacion_Internalname), 1);
                  n7TrGestionTableros_FechaCreacion = false;
                  AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
               }
               n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Modificacion del tablero"}), 1, "TRGESTIONTABLEROS_FECHAMODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_FechaModificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
                  n8TrGestionTableros_FechaModificacion = false;
                  AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
               }
               else
               {
                  A8TrGestionTableros_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrGestionTableros_FechaModificacion_Internalname), 1);
                  n8TrGestionTableros_FechaModificacion = false;
                  AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
               }
               n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
               cmbTrGestionTableros_Estado.CurrentValue = cgiGet( cmbTrGestionTableros_Estado_Internalname);
               A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrGestionTableros_Estado_Internalname), "."));
               n10TrGestionTableros_Estado = false;
               AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
               n10TrGestionTableros_Estado = ((0==A10TrGestionTableros_Estado) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A1TrGestionTableros_ID = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
                  AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
                  getEqualNoModal( ) ;
                  if ( IsIns( )  )
                  {
                     A1TrGestionTableros_ID = (Guid)(AV7GUID);
                     AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
                  }
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  getEqualNoModal( ) ;
                  standaloneModal( ) ;
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E11012 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E12012 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 btn_enter( ) ;
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOCANCEL'") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                              }
                           }
                           nKeyPressed = 3;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 AfterKeyLoadScreen( ) ;
                              }
                           }
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: After Trn */
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         AssignProp(sPrefix, false, edtTrGestionTableros_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Nombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_Comentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Comentario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Descripcion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_TipoTablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_TipoTablero_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaInicio_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaFin_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaCreacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaModificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, cmbTrGestionTableros_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrGestionTableros_Estado.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
      }

      protected void disable_std_buttons_dsp( )
      {
         if ( IsDsp( ) )
         {
            bttEnter_Visible = 0;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
         }
         DisableAttributes011( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
      }

      protected void E12012( )
      {
         /* After Trn Routine */
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2TrGestionTableros_Nombre = T00013_A2TrGestionTableros_Nombre[0];
               Z9TrGestionTableros_TipoTablero = T00013_A9TrGestionTableros_TipoTablero[0];
               Z3TrGestionTableros_FechaInicio = T00013_A3TrGestionTableros_FechaInicio[0];
               Z4TrGestionTableros_FechaFin = T00013_A4TrGestionTableros_FechaFin[0];
               Z7TrGestionTableros_FechaCreacion = T00013_A7TrGestionTableros_FechaCreacion[0];
               Z8TrGestionTableros_FechaModificacion = T00013_A8TrGestionTableros_FechaModificacion[0];
               Z10TrGestionTableros_Estado = T00013_A10TrGestionTableros_Estado[0];
            }
            else
            {
               Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
               Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
               Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
               Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
               Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
               Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
               Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
            }
         }
         if ( GX_JID == -10 )
         {
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z6TrGestionTableros_Comentario = A6TrGestionTableros_Comentario;
            Z5TrGestionTableros_Descripcion = A5TrGestionTableros_Descripcion;
            Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
            Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTrGestionTableros_ID_Enabled = 1;
         AssignProp(sPrefix, false, edtTrGestionTableros_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Enabled), 5, 0), true);
         AV7GUID = (Guid)(Guid.NewGuid( ));
         AssignAttri(sPrefix, false, "AV7GUID", AV7GUID.ToString());
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1TrGestionTableros_ID = (Guid)(AV7GUID);
            AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttEnter_Enabled = 0;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
         else
         {
            bttEnter_Enabled = 1;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2TrGestionTableros_Nombre = T00014_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = T00014_n2TrGestionTableros_Nombre[0];
            AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
            A6TrGestionTableros_Comentario = T00014_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = T00014_n6TrGestionTableros_Comentario[0];
            AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
            A5TrGestionTableros_Descripcion = T00014_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = T00014_n5TrGestionTableros_Descripcion[0];
            AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
            A9TrGestionTableros_TipoTablero = T00014_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = T00014_n9TrGestionTableros_TipoTablero[0];
            AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            A3TrGestionTableros_FechaInicio = T00014_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = T00014_n3TrGestionTableros_FechaInicio[0];
            AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            A4TrGestionTableros_FechaFin = T00014_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = T00014_n4TrGestionTableros_FechaFin[0];
            AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            A7TrGestionTableros_FechaCreacion = T00014_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = T00014_n7TrGestionTableros_FechaCreacion[0];
            AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            A8TrGestionTableros_FechaModificacion = T00014_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = T00014_n8TrGestionTableros_FechaModificacion[0];
            AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            A10TrGestionTableros_Estado = T00014_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = T00014_n10TrGestionTableros_Estado[0];
            AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
            ZM011( -10) ;
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
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A3TrGestionTableros_FechaInicio) || ( A3TrGestionTableros_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Inicio is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAINICIO");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaInicio_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A4TrGestionTableros_FechaFin) || ( A4TrGestionTableros_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Fin is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAFIN");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaFin_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A7TrGestionTableros_FechaCreacion) || ( A7TrGestionTableros_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Creacion del tablero is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaCreacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A8TrGestionTableros_FechaModificacion) || ( A8TrGestionTableros_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Modificacion del tablero is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_FechaModificacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A10TrGestionTableros_Estado == 1 ) || ( A10TrGestionTableros_Estado == 2 ) || ( A10TrGestionTableros_Estado == 3 ) || ( A10TrGestionTableros_Estado == 4 ) || ( A10TrGestionTableros_Estado == 5 ) || (0==A10TrGestionTableros_Estado) ) )
         {
            GX_msglist.addItem("Field Estado del tablero is out of range", "OutOfRange", 1, "TRGESTIONTABLEROS_ESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTrGestionTableros_Estado_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         /* Using cursor T00015 */
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
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 10) ;
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T00013_A1TrGestionTableros_ID[0]));
            AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
            A2TrGestionTableros_Nombre = T00013_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = T00013_n2TrGestionTableros_Nombre[0];
            AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
            A6TrGestionTableros_Comentario = T00013_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = T00013_n6TrGestionTableros_Comentario[0];
            AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
            A5TrGestionTableros_Descripcion = T00013_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = T00013_n5TrGestionTableros_Descripcion[0];
            AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
            A9TrGestionTableros_TipoTablero = T00013_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = T00013_n9TrGestionTableros_TipoTablero[0];
            AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
            A3TrGestionTableros_FechaInicio = T00013_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = T00013_n3TrGestionTableros_FechaInicio[0];
            AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
            A4TrGestionTableros_FechaFin = T00013_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = T00013_n4TrGestionTableros_FechaFin[0];
            AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
            A7TrGestionTableros_FechaCreacion = T00013_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = T00013_n7TrGestionTableros_FechaCreacion[0];
            AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
            A8TrGestionTableros_FechaModificacion = T00013_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = T00013_n8TrGestionTableros_FechaModificacion[0];
            AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
            A10TrGestionTableros_Estado = T00013_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = T00013_n10TrGestionTableros_Estado[0];
            AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00016_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00016_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) > 0 ) ) )
            {
               A1TrGestionTableros_ID = (Guid)((Guid)(T00016_A1TrGestionTableros_ID[0]));
               AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00017_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00017_A1TrGestionTableros_ID[0], A1TrGestionTableros_ID, 1) < 0 ) ) )
            {
               A1TrGestionTableros_ID = (Guid)((Guid)(T00017_A1TrGestionTableros_ID[0]));
               AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
                  AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRGESTIONTABLEROS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRGESTIONTABLEROS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrGestionTableros_ID_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
         {
            A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
            AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRGESTIONTABLEROS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRGESTIONTABLEROS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrGestionTableros_ID_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, T00012_A2TrGestionTableros_Nombre[0]) != 0 ) || ( Z9TrGestionTableros_TipoTablero != T00012_A9TrGestionTableros_TipoTablero[0] ) || ( Z3TrGestionTableros_FechaInicio != T00012_A3TrGestionTableros_FechaInicio[0] ) || ( Z4TrGestionTableros_FechaFin != T00012_A4TrGestionTableros_FechaFin[0] ) || ( Z7TrGestionTableros_FechaCreacion != T00012_A7TrGestionTableros_FechaCreacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z8TrGestionTableros_FechaModificacion != T00012_A8TrGestionTableros_FechaModificacion[0] ) || ( Z10TrGestionTableros_Estado != T00012_A10TrGestionTableros_Estado[0] ) )
            {
               if ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, T00012_A2TrGestionTableros_Nombre[0]) != 0 )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_Nombre");
                  GXUtil.WriteLogRaw("Old: ",Z2TrGestionTableros_Nombre);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2TrGestionTableros_Nombre[0]);
               }
               if ( Z9TrGestionTableros_TipoTablero != T00012_A9TrGestionTableros_TipoTablero[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_TipoTablero");
                  GXUtil.WriteLogRaw("Old: ",Z9TrGestionTableros_TipoTablero);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9TrGestionTableros_TipoTablero[0]);
               }
               if ( Z3TrGestionTableros_FechaInicio != T00012_A3TrGestionTableros_FechaInicio[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaInicio");
                  GXUtil.WriteLogRaw("Old: ",Z3TrGestionTableros_FechaInicio);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3TrGestionTableros_FechaInicio[0]);
               }
               if ( Z4TrGestionTableros_FechaFin != T00012_A4TrGestionTableros_FechaFin[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaFin");
                  GXUtil.WriteLogRaw("Old: ",Z4TrGestionTableros_FechaFin);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4TrGestionTableros_FechaFin[0]);
               }
               if ( Z7TrGestionTableros_FechaCreacion != T00012_A7TrGestionTableros_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z7TrGestionTableros_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7TrGestionTableros_FechaCreacion[0]);
               }
               if ( Z8TrGestionTableros_FechaModificacion != T00012_A8TrGestionTableros_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z8TrGestionTableros_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8TrGestionTableros_FechaModificacion[0]);
               }
               if ( Z10TrGestionTableros_Estado != T00012_A10TrGestionTableros_Estado[0] )
               {
                  GXUtil.WriteLog("trgestiontableros:[seudo value changed for attri]"+"TrGestionTableros_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z10TrGestionTableros_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00012_A10TrGestionTableros_Estado[0]);
               }
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
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption010( ) ;
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
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado, A1TrGestionTableros_ID});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(7) == 103) )
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
                           ResetCaption010( ) ;
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
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1TrGestionTableros_ID});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
                           Gx_mode = "INS";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        }
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                        ResetCaption010( ) ;
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
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000111 */
            pr_default.execute(9, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tr Gestion Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
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
            pr_default.close(1);
            context.CommitDataStores("trgestiontableros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trgestiontableros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000112 */
         pr_default.execute(10);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T000112_A1TrGestionTableros_ID[0]));
            AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(T000112_A1TrGestionTableros_ID[0]));
            AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(10);
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
         edtTrGestionTableros_ID_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_ID_Enabled), 5, 0), true);
         edtTrGestionTableros_Nombre_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_Nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Nombre_Enabled), 5, 0), true);
         edtTrGestionTableros_Comentario_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_Comentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Comentario_Enabled), 5, 0), true);
         edtTrGestionTableros_Descripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_Descripcion_Enabled), 5, 0), true);
         edtTrGestionTableros_TipoTablero_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_TipoTablero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_TipoTablero_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaInicio_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaInicio_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaFin_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaFin_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaCreacion_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaCreacion_Enabled), 5, 0), true);
         edtTrGestionTableros_FechaModificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtTrGestionTableros_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrGestionTableros_FechaModificacion_Enabled), 5, 0), true);
         cmbTrGestionTableros_Estado.Enabled = 0;
         AssignProp(sPrefix, false, cmbTrGestionTableros_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrGestionTableros_Estado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Nombre de tablero") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210202185219", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trgestiontableros.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z1TrGestionTableros_ID", Z1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2TrGestionTableros_Nombre", StringUtil.RTrim( Z2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z3TrGestionTableros_FechaInicio", context.localUtil.DToC( Z3TrGestionTableros_FechaInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z4TrGestionTableros_FechaFin", context.localUtil.DToC( Z4TrGestionTableros_FechaFin, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z7TrGestionTableros_FechaCreacion", context.localUtil.DToC( Z7TrGestionTableros_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z8TrGestionTableros_FechaModificacion", context.localUtil.DToC( Z8TrGestionTableros_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z10TrGestionTableros_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10TrGestionTableros_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGUID", AV7GUID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm011( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("trgestiontableros.js", "?202210202185225", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "TrGestionTableros" ;
      }

      public override String GetPgmdesc( )
      {
         return "Nombre de tablero" ;
      }

      protected void InitializeNonKey011( )
      {
         A2TrGestionTableros_Nombre = "";
         n2TrGestionTableros_Nombre = false;
         AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", A2TrGestionTableros_Nombre);
         n2TrGestionTableros_Nombre = (String.IsNullOrEmpty(StringUtil.RTrim( A2TrGestionTableros_Nombre)) ? true : false);
         A6TrGestionTableros_Comentario = "";
         n6TrGestionTableros_Comentario = false;
         AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
         n6TrGestionTableros_Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A6TrGestionTableros_Comentario)) ? true : false);
         A5TrGestionTableros_Descripcion = "";
         n5TrGestionTableros_Descripcion = false;
         AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
         n5TrGestionTableros_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A5TrGestionTableros_Descripcion)) ? true : false);
         A9TrGestionTableros_TipoTablero = 0;
         n9TrGestionTableros_TipoTablero = false;
         AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrimStr( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0));
         n9TrGestionTableros_TipoTablero = ((0==A9TrGestionTableros_TipoTablero) ? true : false);
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         n3TrGestionTableros_FechaInicio = false;
         AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         n3TrGestionTableros_FechaInicio = ((DateTime.MinValue==A3TrGestionTableros_FechaInicio) ? true : false);
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         n4TrGestionTableros_FechaFin = false;
         AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
         n4TrGestionTableros_FechaFin = ((DateTime.MinValue==A4TrGestionTableros_FechaFin) ? true : false);
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         n7TrGestionTableros_FechaCreacion = false;
         AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
         n7TrGestionTableros_FechaCreacion = ((DateTime.MinValue==A7TrGestionTableros_FechaCreacion) ? true : false);
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         n8TrGestionTableros_FechaModificacion = false;
         AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
         n8TrGestionTableros_FechaModificacion = ((DateTime.MinValue==A8TrGestionTableros_FechaModificacion) ? true : false);
         A10TrGestionTableros_Estado = 0;
         n10TrGestionTableros_Estado = false;
         AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         n10TrGestionTableros_Estado = ((0==A10TrGestionTableros_Estado) ? true : false);
         Z2TrGestionTableros_Nombre = "";
         Z9TrGestionTableros_TipoTablero = 0;
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         Z10TrGestionTableros_Estado = 0;
      }

      protected void InitAll011( )
      {
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         AssignAttri(sPrefix, false, "A1TrGestionTableros_ID", A1TrGestionTableros_ID.ToString());
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trgestiontableros", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         Draw( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("K2BControlBeautify/montrezorro-bootstrap-checkbox/css/bootstrap-checkbox.css", "");
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202185235", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trgestiontableros.js", "?202210202185236", false, true);
         context.AddJavascriptSource("K2BControlBeautify/montrezorro-bootstrap-checkbox/js/bootstrap-checkbox.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         lblTextblocktrgestiontableros_id_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_ID";
         edtTrGestionTableros_ID_Internalname = sPrefix+"TRGESTIONTABLEROS_ID";
         divK2btoolstable_attributecontainertrgestiontableros_id_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_ID";
         divTabularcell_trgestiontableros_id_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_ID";
         lblTextblocktrgestiontableros_nombre_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_NOMBRE";
         edtTrGestionTableros_Nombre_Internalname = sPrefix+"TRGESTIONTABLEROS_NOMBRE";
         divK2btoolstable_attributecontainertrgestiontableros_nombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_NOMBRE";
         divTabularcell_trgestiontableros_nombre_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_NOMBRE";
         lblTextblocktrgestiontableros_comentario_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_COMENTARIO";
         edtTrGestionTableros_Comentario_Internalname = sPrefix+"TRGESTIONTABLEROS_COMENTARIO";
         divK2btoolstable_attributecontainertrgestiontableros_comentario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_COMENTARIO";
         divTabularcell_trgestiontableros_comentario_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_COMENTARIO";
         lblTextblocktrgestiontableros_descripcion_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_DESCRIPCION";
         edtTrGestionTableros_Descripcion_Internalname = sPrefix+"TRGESTIONTABLEROS_DESCRIPCION";
         divK2btoolstable_attributecontainertrgestiontableros_descripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_DESCRIPCION";
         divTabularcell_trgestiontableros_descripcion_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_DESCRIPCION";
         lblTextblocktrgestiontableros_tipotablero_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_TIPOTABLERO";
         edtTrGestionTableros_TipoTablero_Internalname = sPrefix+"TRGESTIONTABLEROS_TIPOTABLERO";
         divK2btoolstable_attributecontainertrgestiontableros_tipotablero_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_TIPOTABLERO";
         divTabularcell_trgestiontableros_tipotablero_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_TIPOTABLERO";
         lblTextblocktrgestiontableros_fechainicio_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_FECHAINICIO";
         edtTrGestionTableros_FechaInicio_Internalname = sPrefix+"TRGESTIONTABLEROS_FECHAINICIO";
         divK2btoolstable_attributecontainertrgestiontableros_fechainicio_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_FECHAINICIO";
         divTabularcell_trgestiontableros_fechainicio_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_FECHAINICIO";
         lblTextblocktrgestiontableros_fechafin_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_FECHAFIN";
         edtTrGestionTableros_FechaFin_Internalname = sPrefix+"TRGESTIONTABLEROS_FECHAFIN";
         divK2btoolstable_attributecontainertrgestiontableros_fechafin_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_FECHAFIN";
         divTabularcell_trgestiontableros_fechafin_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_FECHAFIN";
         lblTextblocktrgestiontableros_fechacreacion_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_FECHACREACION";
         edtTrGestionTableros_FechaCreacion_Internalname = sPrefix+"TRGESTIONTABLEROS_FECHACREACION";
         divK2btoolstable_attributecontainertrgestiontableros_fechacreacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_FECHACREACION";
         divTabularcell_trgestiontableros_fechacreacion_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_FECHACREACION";
         lblTextblocktrgestiontableros_fechamodificacion_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_FECHAMODIFICACION";
         edtTrGestionTableros_FechaModificacion_Internalname = sPrefix+"TRGESTIONTABLEROS_FECHAMODIFICACION";
         divK2btoolstable_attributecontainertrgestiontableros_fechamodificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_FECHAMODIFICACION";
         divTabularcell_trgestiontableros_fechamodificacion_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_FECHAMODIFICACION";
         lblTextblocktrgestiontableros_estado_Internalname = sPrefix+"TEXTBLOCKTRGESTIONTABLEROS_ESTADO";
         cmbTrGestionTableros_Estado_Internalname = sPrefix+"TRGESTIONTABLEROS_ESTADO";
         divK2btoolstable_attributecontainertrgestiontableros_estado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRGESTIONTABLEROS_ESTADO";
         divTabularcell_trgestiontableros_estado_Internalname = sPrefix+"TABULARCELL_TRGESTIONTABLEROS_ESTADO";
         divK2btabletabulardatatrgestiontableros_Internalname = sPrefix+"K2BTABLETABULARDATATRGESTIONTABLEROS";
         divK2btabulardatacellcontainertrgestiontableros_Internalname = sPrefix+"K2BTABULARDATACELLCONTAINERTRGESTIONTABLEROS";
         divK2bentityservicesroottable_Internalname = sPrefix+"K2BENTITYSERVICESROOTTABLE";
         divK2bentityservicesroottablecell_Internalname = sPrefix+"K2BENTITYSERVICESROOTTABLECELL";
         divK2babstracttabledataareacontainer_Internalname = sPrefix+"K2BABSTRACTTABLEDATAAREACONTAINER";
         divK2besdataareacontainercell_Internalname = sPrefix+"K2BESDATAAREACONTAINERCELL";
         bttEnter_Internalname = sPrefix+"ENTER";
         bttCancel_Internalname = sPrefix+"CANCEL";
         tblActionscontainerbuttons_Internalname = sPrefix+"ACTIONSCONTAINERBUTTONS";
         divK2besactioncontainercell_Internalname = sPrefix+"K2BESACTIONCONTAINERCELL";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divK2bescontrolbeaufitycell_Internalname = sPrefix+"K2BESCONTROLBEAUFITYCELL";
         divK2besmaintable_Internalname = sPrefix+"K2BESMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         bttCancel_Visible = 1;
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         cmbTrGestionTableros_Estado_Jsonclick = "";
         cmbTrGestionTableros_Estado.Enabled = 1;
         edtTrGestionTableros_FechaModificacion_Jsonclick = "";
         edtTrGestionTableros_FechaModificacion_Enabled = 1;
         edtTrGestionTableros_FechaCreacion_Jsonclick = "";
         edtTrGestionTableros_FechaCreacion_Enabled = 1;
         edtTrGestionTableros_FechaFin_Jsonclick = "";
         edtTrGestionTableros_FechaFin_Enabled = 1;
         edtTrGestionTableros_FechaInicio_Jsonclick = "";
         edtTrGestionTableros_FechaInicio_Enabled = 1;
         edtTrGestionTableros_TipoTablero_Jsonclick = "";
         edtTrGestionTableros_TipoTablero_Enabled = 1;
         edtTrGestionTableros_Descripcion_Enabled = 1;
         edtTrGestionTableros_Comentario_Enabled = 1;
         edtTrGestionTableros_Nombre_Jsonclick = "";
         edtTrGestionTableros_Nombre_Enabled = 1;
         edtTrGestionTableros_ID_Jsonclick = "";
         edtTrGestionTableros_ID_Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbTrGestionTableros_Estado.Name = "TRGESTIONTABLEROS_ESTADO";
         cmbTrGestionTableros_Estado.WebTags = "";
         cmbTrGestionTableros_Estado.addItem("1", "Nuevo", 0);
         cmbTrGestionTableros_Estado.addItem("2", "En Progreso", 0);
         cmbTrGestionTableros_Estado.addItem("3", "Completado", 0);
         cmbTrGestionTableros_Estado.addItem("4", "Detenido", 0);
         cmbTrGestionTableros_Estado.addItem("5", "Pendiente", 0);
         if ( cmbTrGestionTableros_Estado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrGestionTableros_Nombre_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Trgestiontableros_id( )
      {
         n10TrGestionTableros_Estado = false;
         A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbTrGestionTableros_Estado.CurrentValue, "."));
         n10TrGestionTableros_Estado = false;
         cmbTrGestionTableros_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0);
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
         {
            standaloneStartupServer( ) ;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            context.wbHandled = 1;
            if ( ! wbErr )
            {
               AfterKeyLoadScreen( ) ;
            }
         }
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTrGestionTableros_Estado.ItemCount > 0 )
         {
            A10TrGestionTableros_Estado = (short)(NumberUtil.Val( cmbTrGestionTableros_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0))), "."));
            n10TrGestionTableros_Estado = false;
            cmbTrGestionTableros_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A10TrGestionTableros_Estado), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrGestionTableros_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A2TrGestionTableros_Nombre", StringUtil.RTrim( A2TrGestionTableros_Nombre));
         AssignAttri(sPrefix, false, "A6TrGestionTableros_Comentario", A6TrGestionTableros_Comentario);
         AssignAttri(sPrefix, false, "A5TrGestionTableros_Descripcion", A5TrGestionTableros_Descripcion);
         AssignAttri(sPrefix, false, "A9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         AssignAttri(sPrefix, false, "A3TrGestionTableros_FechaInicio", context.localUtil.Format(A3TrGestionTableros_FechaInicio, "99/99/9999"));
         AssignAttri(sPrefix, false, "A4TrGestionTableros_FechaFin", context.localUtil.Format(A4TrGestionTableros_FechaFin, "99/99/9999"));
         AssignAttri(sPrefix, false, "A7TrGestionTableros_FechaCreacion", context.localUtil.Format(A7TrGestionTableros_FechaCreacion, "99/99/9999"));
         AssignAttri(sPrefix, false, "A8TrGestionTableros_FechaModificacion", context.localUtil.Format(A8TrGestionTableros_FechaModificacion, "99/99/9999"));
         AssignAttri(sPrefix, false, "A10TrGestionTableros_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10TrGestionTableros_Estado), 4, 0, ".", "")));
         cmbTrGestionTableros_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10TrGestionTableros_Estado), 4, 0));
         AssignProp(sPrefix, false, cmbTrGestionTableros_Estado_Internalname, "Values", cmbTrGestionTableros_Estado.ToJavascriptSource(), true);
         AssignAttri(sPrefix, false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z1TrGestionTableros_ID", Z1TrGestionTableros_ID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"Z2TrGestionTableros_Nombre", StringUtil.RTrim( Z2TrGestionTableros_Nombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z6TrGestionTableros_Comentario", Z6TrGestionTableros_Comentario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z5TrGestionTableros_Descripcion", Z5TrGestionTableros_Descripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z9TrGestionTableros_TipoTablero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9TrGestionTableros_TipoTablero), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z3TrGestionTableros_FechaInicio", context.localUtil.Format(Z3TrGestionTableros_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z4TrGestionTableros_FechaFin", context.localUtil.Format(Z4TrGestionTableros_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z7TrGestionTableros_FechaCreacion", context.localUtil.Format(Z7TrGestionTableros_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z8TrGestionTableros_FechaModificacion", context.localUtil.Format(Z8TrGestionTableros_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z10TrGestionTableros_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10TrGestionTableros_Estado), 4, 0, ".", "")));
         AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ID","{handler:'Valid_Trgestiontableros_id',iparms:[{av:'cmbTrGestionTableros_Estado'},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'},{av:'A1TrGestionTableros_ID',fld:'TRGESTIONTABLEROS_ID',pic:''},{av:'AV7GUID',fld:'vGUID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ID",",oparms:[{av:'A2TrGestionTableros_Nombre',fld:'TRGESTIONTABLEROS_NOMBRE',pic:''},{av:'A6TrGestionTableros_Comentario',fld:'TRGESTIONTABLEROS_COMENTARIO',pic:''},{av:'A5TrGestionTableros_Descripcion',fld:'TRGESTIONTABLEROS_DESCRIPCION',pic:''},{av:'A9TrGestionTableros_TipoTablero',fld:'TRGESTIONTABLEROS_TIPOTABLERO',pic:'ZZZ9'},{av:'A3TrGestionTableros_FechaInicio',fld:'TRGESTIONTABLEROS_FECHAINICIO',pic:''},{av:'A4TrGestionTableros_FechaFin',fld:'TRGESTIONTABLEROS_FECHAFIN',pic:''},{av:'A7TrGestionTableros_FechaCreacion',fld:'TRGESTIONTABLEROS_FECHACREACION',pic:''},{av:'A8TrGestionTableros_FechaModificacion',fld:'TRGESTIONTABLEROS_FECHAMODIFICACION',pic:''},{av:'cmbTrGestionTableros_Estado'},{av:'A10TrGestionTableros_Estado',fld:'TRGESTIONTABLEROS_ESTADO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1TrGestionTableros_ID'},{av:'Z2TrGestionTableros_Nombre'},{av:'Z6TrGestionTableros_Comentario'},{av:'Z5TrGestionTableros_Descripcion'},{av:'Z9TrGestionTableros_TipoTablero'},{av:'Z3TrGestionTableros_FechaInicio'},{av:'Z4TrGestionTableros_FechaFin'},{av:'Z7TrGestionTableros_FechaCreacion'},{av:'Z8TrGestionTableros_FechaModificacion'},{av:'Z10TrGestionTableros_Estado'},{ctrl:'ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAINICIO","{handler:'Valid_Trgestiontableros_fechainicio',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAFIN","{handler:'Valid_Trgestiontableros_fechafin',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHACREACION","{handler:'Valid_Trgestiontableros_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAMODIFICACION","{handler:'Valid_Trgestiontableros_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ESTADO","{handler:'Valid_Trgestiontableros_estado',iparms:[]");
         setEventMetadata("VALID_TRGESTIONTABLEROS_ESTADO",",oparms:[]}");
         return  ;
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
         sPrefix = "";
         Z1TrGestionTableros_ID = (Guid)(Guid.Empty);
         Z2TrGestionTableros_Nombre = "";
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTextblocktrgestiontableros_id_Jsonclick = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         TempTags = "";
         lblTextblocktrgestiontableros_nombre_Jsonclick = "";
         A2TrGestionTableros_Nombre = "";
         lblTextblocktrgestiontableros_comentario_Jsonclick = "";
         A6TrGestionTableros_Comentario = "";
         lblTextblocktrgestiontableros_descripcion_Jsonclick = "";
         A5TrGestionTableros_Descripcion = "";
         lblTextblocktrgestiontableros_tipotablero_Jsonclick = "";
         lblTextblocktrgestiontableros_fechainicio_Jsonclick = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         lblTextblocktrgestiontableros_fechafin_Jsonclick = "";
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         lblTextblocktrgestiontableros_fechacreacion_Jsonclick = "";
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         lblTextblocktrgestiontableros_fechamodificacion_Jsonclick = "";
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         lblTextblocktrgestiontableros_estado_Jsonclick = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Gx_mode = "";
         AV7GUID = (Guid)(Guid.Empty);
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z6TrGestionTableros_Comentario = "";
         Z5TrGestionTableros_Descripcion = "";
         T00014_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00014_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00014_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00014_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00014_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00014_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00014_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00014_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00014_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00014_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00014_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00014_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00014_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00014_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00014_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00014_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00014_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00014_A10TrGestionTableros_Estado = new short[1] ;
         T00014_n10TrGestionTableros_Estado = new bool[] {false} ;
         T00015_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00013_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00013_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00013_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00013_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00013_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00013_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00013_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00013_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00013_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00013_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00013_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00013_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00013_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00013_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00013_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00013_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00013_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00013_A10TrGestionTableros_Estado = new short[1] ;
         T00013_n10TrGestionTableros_Estado = new bool[] {false} ;
         sMode1 = "";
         T00016_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00017_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00012_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         T00012_A2TrGestionTableros_Nombre = new String[] {""} ;
         T00012_n2TrGestionTableros_Nombre = new bool[] {false} ;
         T00012_A6TrGestionTableros_Comentario = new String[] {""} ;
         T00012_n6TrGestionTableros_Comentario = new bool[] {false} ;
         T00012_A5TrGestionTableros_Descripcion = new String[] {""} ;
         T00012_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         T00012_A9TrGestionTableros_TipoTablero = new short[1] ;
         T00012_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         T00012_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         T00012_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         T00012_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         T00012_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         T00012_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00012_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         T00012_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00012_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         T00012_A10TrGestionTableros_Estado = new short[1] ;
         T00012_n10TrGestionTableros_Estado = new bool[] {false} ;
         T000111_A12TrGestionTareas_ID = new long[1] ;
         T000112_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ZZ1TrGestionTableros_ID = (Guid)(Guid.Empty);
         ZZ2TrGestionTableros_Nombre = "";
         ZZ6TrGestionTableros_Comentario = "";
         ZZ5TrGestionTableros_Descripcion = "";
         ZZ3TrGestionTableros_FechaInicio = DateTime.MinValue;
         ZZ4TrGestionTableros_FechaFin = DateTime.MinValue;
         ZZ7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         ZZ8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontableros__default(),
            new Object[][] {
                new Object[] {
               T00012_A1TrGestionTableros_ID, T00012_A2TrGestionTableros_Nombre, T00012_n2TrGestionTableros_Nombre, T00012_A6TrGestionTableros_Comentario, T00012_n6TrGestionTableros_Comentario, T00012_A5TrGestionTableros_Descripcion, T00012_n5TrGestionTableros_Descripcion, T00012_A9TrGestionTableros_TipoTablero, T00012_n9TrGestionTableros_TipoTablero, T00012_A3TrGestionTableros_FechaInicio,
               T00012_n3TrGestionTableros_FechaInicio, T00012_A4TrGestionTableros_FechaFin, T00012_n4TrGestionTableros_FechaFin, T00012_A7TrGestionTableros_FechaCreacion, T00012_n7TrGestionTableros_FechaCreacion, T00012_A8TrGestionTableros_FechaModificacion, T00012_n8TrGestionTableros_FechaModificacion, T00012_A10TrGestionTableros_Estado, T00012_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00013_A1TrGestionTableros_ID, T00013_A2TrGestionTableros_Nombre, T00013_n2TrGestionTableros_Nombre, T00013_A6TrGestionTableros_Comentario, T00013_n6TrGestionTableros_Comentario, T00013_A5TrGestionTableros_Descripcion, T00013_n5TrGestionTableros_Descripcion, T00013_A9TrGestionTableros_TipoTablero, T00013_n9TrGestionTableros_TipoTablero, T00013_A3TrGestionTableros_FechaInicio,
               T00013_n3TrGestionTableros_FechaInicio, T00013_A4TrGestionTableros_FechaFin, T00013_n4TrGestionTableros_FechaFin, T00013_A7TrGestionTableros_FechaCreacion, T00013_n7TrGestionTableros_FechaCreacion, T00013_A8TrGestionTableros_FechaModificacion, T00013_n8TrGestionTableros_FechaModificacion, T00013_A10TrGestionTableros_Estado, T00013_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00014_A1TrGestionTableros_ID, T00014_A2TrGestionTableros_Nombre, T00014_n2TrGestionTableros_Nombre, T00014_A6TrGestionTableros_Comentario, T00014_n6TrGestionTableros_Comentario, T00014_A5TrGestionTableros_Descripcion, T00014_n5TrGestionTableros_Descripcion, T00014_A9TrGestionTableros_TipoTablero, T00014_n9TrGestionTableros_TipoTablero, T00014_A3TrGestionTableros_FechaInicio,
               T00014_n3TrGestionTableros_FechaInicio, T00014_A4TrGestionTableros_FechaFin, T00014_n4TrGestionTableros_FechaFin, T00014_A7TrGestionTableros_FechaCreacion, T00014_n7TrGestionTableros_FechaCreacion, T00014_A8TrGestionTableros_FechaModificacion, T00014_n8TrGestionTableros_FechaModificacion, T00014_A10TrGestionTableros_Estado, T00014_n10TrGestionTableros_Estado
               }
               , new Object[] {
               T00015_A1TrGestionTableros_ID
               }
               , new Object[] {
               T00016_A1TrGestionTableros_ID
               }
               , new Object[] {
               T00017_A1TrGestionTableros_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A12TrGestionTareas_ID
               }
               , new Object[] {
               T000112_A1TrGestionTableros_ID
               }
            }
         );
      }

      private short Z9TrGestionTableros_TipoTablero ;
      private short Z10TrGestionTableros_Estado ;
      private short GxWebError ;
      private short nDynComponent ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A10TrGestionTableros_Estado ;
      private short A9TrGestionTableros_TipoTablero ;
      private short nDraw ;
      private short nDoneStart ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short ZZ9TrGestionTableros_TipoTablero ;
      private short ZZ10TrGestionTableros_Estado ;
      private int trnEnded ;
      private int edtTrGestionTableros_ID_Enabled ;
      private int edtTrGestionTableros_Nombre_Enabled ;
      private int edtTrGestionTableros_Comentario_Enabled ;
      private int edtTrGestionTableros_Descripcion_Enabled ;
      private int edtTrGestionTableros_TipoTablero_Enabled ;
      private int edtTrGestionTableros_FechaInicio_Enabled ;
      private int edtTrGestionTableros_FechaFin_Enabled ;
      private int edtTrGestionTableros_FechaCreacion_Enabled ;
      private int edtTrGestionTableros_FechaModificacion_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int idxLst ;
      private String sPrefix ;
      private String Z2TrGestionTableros_Nombre ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String sXEvt ;
      private String GX_FocusControl ;
      private String edtTrGestionTableros_ID_Internalname ;
      private String cmbTrGestionTableros_Estado_Internalname ;
      private String divK2besmaintable_Internalname ;
      private String divK2beserrviewercell_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divK2besdataareacontainercell_Internalname ;
      private String divK2babstracttabledataareacontainer_Internalname ;
      private String divK2bentityservicesroottablecell_Internalname ;
      private String divK2bentityservicesroottable_Internalname ;
      private String divK2btabulardatacellcontainertrgestiontableros_Internalname ;
      private String divK2btabletabulardatatrgestiontableros_Internalname ;
      private String divTabularcell_trgestiontableros_id_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_id_Internalname ;
      private String lblTextblocktrgestiontableros_id_Internalname ;
      private String lblTextblocktrgestiontableros_id_Jsonclick ;
      private String TempTags ;
      private String edtTrGestionTableros_ID_Jsonclick ;
      private String divTabularcell_trgestiontableros_nombre_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_nombre_Internalname ;
      private String lblTextblocktrgestiontableros_nombre_Internalname ;
      private String lblTextblocktrgestiontableros_nombre_Jsonclick ;
      private String edtTrGestionTableros_Nombre_Internalname ;
      private String A2TrGestionTableros_Nombre ;
      private String edtTrGestionTableros_Nombre_Jsonclick ;
      private String divTabularcell_trgestiontableros_comentario_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_comentario_Internalname ;
      private String lblTextblocktrgestiontableros_comentario_Internalname ;
      private String lblTextblocktrgestiontableros_comentario_Jsonclick ;
      private String edtTrGestionTableros_Comentario_Internalname ;
      private String divTabularcell_trgestiontableros_descripcion_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_descripcion_Internalname ;
      private String lblTextblocktrgestiontableros_descripcion_Internalname ;
      private String lblTextblocktrgestiontableros_descripcion_Jsonclick ;
      private String edtTrGestionTableros_Descripcion_Internalname ;
      private String divTabularcell_trgestiontableros_tipotablero_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_tipotablero_Internalname ;
      private String lblTextblocktrgestiontableros_tipotablero_Internalname ;
      private String lblTextblocktrgestiontableros_tipotablero_Jsonclick ;
      private String edtTrGestionTableros_TipoTablero_Internalname ;
      private String edtTrGestionTableros_TipoTablero_Jsonclick ;
      private String divTabularcell_trgestiontableros_fechainicio_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_fechainicio_Internalname ;
      private String lblTextblocktrgestiontableros_fechainicio_Internalname ;
      private String lblTextblocktrgestiontableros_fechainicio_Jsonclick ;
      private String edtTrGestionTableros_FechaInicio_Internalname ;
      private String edtTrGestionTableros_FechaInicio_Jsonclick ;
      private String divTabularcell_trgestiontableros_fechafin_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_fechafin_Internalname ;
      private String lblTextblocktrgestiontableros_fechafin_Internalname ;
      private String lblTextblocktrgestiontableros_fechafin_Jsonclick ;
      private String edtTrGestionTableros_FechaFin_Internalname ;
      private String edtTrGestionTableros_FechaFin_Jsonclick ;
      private String divTabularcell_trgestiontableros_fechacreacion_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_fechacreacion_Internalname ;
      private String lblTextblocktrgestiontableros_fechacreacion_Internalname ;
      private String lblTextblocktrgestiontableros_fechacreacion_Jsonclick ;
      private String edtTrGestionTableros_FechaCreacion_Internalname ;
      private String edtTrGestionTableros_FechaCreacion_Jsonclick ;
      private String divTabularcell_trgestiontableros_fechamodificacion_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_fechamodificacion_Internalname ;
      private String lblTextblocktrgestiontableros_fechamodificacion_Internalname ;
      private String lblTextblocktrgestiontableros_fechamodificacion_Jsonclick ;
      private String edtTrGestionTableros_FechaModificacion_Internalname ;
      private String edtTrGestionTableros_FechaModificacion_Jsonclick ;
      private String divTabularcell_trgestiontableros_estado_Internalname ;
      private String divK2btoolstable_attributecontainertrgestiontableros_estado_Internalname ;
      private String lblTextblocktrgestiontableros_estado_Internalname ;
      private String lblTextblocktrgestiontableros_estado_Jsonclick ;
      private String cmbTrGestionTableros_Estado_Jsonclick ;
      private String divK2besactioncontainercell_Internalname ;
      private String sStyleString ;
      private String tblActionscontainerbuttons_Internalname ;
      private String bttEnter_Internalname ;
      private String bttEnter_Jsonclick ;
      private String bttCancel_Internalname ;
      private String bttCancel_Jsonclick ;
      private String divK2bescontrolbeaufitycell_Internalname ;
      private String K2bcontrolbeautify1_Internalname ;
      private String Gx_mode ;
      private String K2bcontrolbeautify1_Objectcall ;
      private String K2bcontrolbeautify1_Class ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sMode1 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String ZZ2TrGestionTableros_Nombre ;
      private DateTime Z3TrGestionTableros_FechaInicio ;
      private DateTime Z4TrGestionTableros_FechaFin ;
      private DateTime Z7TrGestionTableros_FechaCreacion ;
      private DateTime Z8TrGestionTableros_FechaModificacion ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private DateTime ZZ3TrGestionTableros_FechaInicio ;
      private DateTime ZZ4TrGestionTableros_FechaFin ;
      private DateTime ZZ7TrGestionTableros_FechaCreacion ;
      private DateTime ZZ8TrGestionTableros_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n10TrGestionTableros_Estado ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool Gx_longc ;
      private String A6TrGestionTableros_Comentario ;
      private String A5TrGestionTableros_Descripcion ;
      private String Z6TrGestionTableros_Comentario ;
      private String Z5TrGestionTableros_Descripcion ;
      private String ZZ6TrGestionTableros_Comentario ;
      private String ZZ5TrGestionTableros_Descripcion ;
      private Guid Z1TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private Guid AV7GUID ;
      private Guid ZZ1TrGestionTableros_ID ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrGestionTableros_Estado ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00014_A1TrGestionTableros_ID ;
      private String[] T00014_A2TrGestionTableros_Nombre ;
      private bool[] T00014_n2TrGestionTableros_Nombre ;
      private String[] T00014_A6TrGestionTableros_Comentario ;
      private bool[] T00014_n6TrGestionTableros_Comentario ;
      private String[] T00014_A5TrGestionTableros_Descripcion ;
      private bool[] T00014_n5TrGestionTableros_Descripcion ;
      private short[] T00014_A9TrGestionTableros_TipoTablero ;
      private bool[] T00014_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00014_A3TrGestionTableros_FechaInicio ;
      private bool[] T00014_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00014_A4TrGestionTableros_FechaFin ;
      private bool[] T00014_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00014_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00014_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00014_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00014_n8TrGestionTableros_FechaModificacion ;
      private short[] T00014_A10TrGestionTableros_Estado ;
      private bool[] T00014_n10TrGestionTableros_Estado ;
      private Guid[] T00015_A1TrGestionTableros_ID ;
      private Guid[] T00013_A1TrGestionTableros_ID ;
      private String[] T00013_A2TrGestionTableros_Nombre ;
      private bool[] T00013_n2TrGestionTableros_Nombre ;
      private String[] T00013_A6TrGestionTableros_Comentario ;
      private bool[] T00013_n6TrGestionTableros_Comentario ;
      private String[] T00013_A5TrGestionTableros_Descripcion ;
      private bool[] T00013_n5TrGestionTableros_Descripcion ;
      private short[] T00013_A9TrGestionTableros_TipoTablero ;
      private bool[] T00013_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00013_A3TrGestionTableros_FechaInicio ;
      private bool[] T00013_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00013_A4TrGestionTableros_FechaFin ;
      private bool[] T00013_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00013_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00013_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00013_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00013_n8TrGestionTableros_FechaModificacion ;
      private short[] T00013_A10TrGestionTableros_Estado ;
      private bool[] T00013_n10TrGestionTableros_Estado ;
      private Guid[] T00016_A1TrGestionTableros_ID ;
      private Guid[] T00017_A1TrGestionTableros_ID ;
      private Guid[] T00012_A1TrGestionTableros_ID ;
      private String[] T00012_A2TrGestionTableros_Nombre ;
      private bool[] T00012_n2TrGestionTableros_Nombre ;
      private String[] T00012_A6TrGestionTableros_Comentario ;
      private bool[] T00012_n6TrGestionTableros_Comentario ;
      private String[] T00012_A5TrGestionTableros_Descripcion ;
      private bool[] T00012_n5TrGestionTableros_Descripcion ;
      private short[] T00012_A9TrGestionTableros_TipoTablero ;
      private bool[] T00012_n9TrGestionTableros_TipoTablero ;
      private DateTime[] T00012_A3TrGestionTableros_FechaInicio ;
      private bool[] T00012_n3TrGestionTableros_FechaInicio ;
      private DateTime[] T00012_A4TrGestionTableros_FechaFin ;
      private bool[] T00012_n4TrGestionTableros_FechaFin ;
      private DateTime[] T00012_A7TrGestionTableros_FechaCreacion ;
      private bool[] T00012_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] T00012_A8TrGestionTableros_FechaModificacion ;
      private bool[] T00012_n8TrGestionTableros_FechaModificacion ;
      private short[] T00012_A10TrGestionTableros_Estado ;
      private bool[] T00012_n10TrGestionTableros_Estado ;
      private long[] T000111_A12TrGestionTareas_ID ;
      private Guid[] T000112_A1TrGestionTableros_ID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00014 ;
          prmT00014 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00015 ;
          prmT00015 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00013 ;
          prmT00013 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00016 ;
          prmT00016 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00017 ;
          prmT00017 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00012 ;
          prmT00012 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT00018 ;
          prmT00018 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmT00019 ;
          prmT00019 = new Object[] {
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000110 ;
          prmT000110 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000111 ;
          prmT000111 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmT000112 ;
          prmT000112 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WITH (UPDLOCK) WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_TipoTablero], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion], TM1.[TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE ( [TrGestionTableros_ID] > @TrGestionTableros_ID) ORDER BY [TrGestionTableros_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE ( [TrGestionTableros_ID] < @TrGestionTableros_ID) ORDER BY [TrGestionTableros_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, @TrGestionTableros_TipoTablero, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_FechaModificacion, @TrGestionTableros_Estado)", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_TipoTablero]=@TrGestionTableros_TipoTablero, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaCreacion]=@TrGestionTableros_FechaCreacion, [TrGestionTableros_FechaModificacion]=@TrGestionTableros_FechaModificacion, [TrGestionTableros_Estado]=@TrGestionTableros_Estado  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT TOP 1 [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_IDTablero] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000112", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] ORDER BY [TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
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
                return;
             case 5 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 6 :
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
                   stmt.setNull( 5 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(5, (short)parms[8]);
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
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 9 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(9, (DateTime)parms[16]);
                }
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 10 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(10, (short)parms[18]);
                }
                return;
             case 7 :
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
                   stmt.setNull( 4 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(4, (short)parms[7]);
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
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 9 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(9, (short)parms[17]);
                }
                stmt.SetParameter(10, (Guid)parms[18]);
                return;
             case 8 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 9 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
