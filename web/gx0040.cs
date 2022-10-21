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
   public class gx0040 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0040( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0040( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pTrActividades_ID )
      {
         this.AV13pTrActividades_ID = 0 ;
         executePrivate();
         aP0_pTrActividades_ID=this.AV13pTrActividades_ID;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_84_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV6cTrActividades_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV7cTrActividades_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV8cTrActividades_Nombre = GetNextPar( );
               AV9cTrActividades_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               AV10cTrActividades_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               AV11cTrActividades_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV12cTrActividades_FechaModificacion = context.localUtil.ParseDateParm( GetNextPar( ));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pTrActividades_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV13pTrActividades_ID), 13, 0));
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA222( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START222( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20221020219033", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0040.aspx") + "?" + UrlEncode("" +AV13pTrActividades_ID)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTrActividades_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_NOMBRE", StringUtil.RTrim( AV8cTrActividades_Nombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_FECHAINICIO", context.localUtil.Format(AV9cTrActividades_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_FECHAFIN", context.localUtil.Format(AV10cTrActividades_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_FECHACREACION", context.localUtil.Format(AV11cTrActividades_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRACTIVIDADES_FECHAMODIFICACION", context.localUtil.Format(AV12cTrActividades_FechaModificacion, "99/99/9999"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pTrActividades_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_IDTAREAFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_idtareafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_NOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_nombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAINICIOFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_fechainiciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAFINFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_fechafinfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHACREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_fechacreacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_FECHAMODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTractividades_fechamodificacionfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE222( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT222( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0040.aspx") + "?" + UrlEncode("" +AV13pTrActividades_ID) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0040" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tr Actividades" ;
      }

      protected void WB220( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_idfilter_Internalname, "Tr Actividades_ID", "", "", lblLbltractividades_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11221_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_id_Internalname, "Tr Actividades_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrActividades_ID), 13, 0, ".", "")), ((edtavCtractividades_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTrActividades_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTrActividades_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtractividades_id_Visible, edtavCtractividades_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_idtareafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_idtareafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_idtareafilter_Internalname, "Tr Actividades_IDTarea", "", "", lblLbltractividades_idtareafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12221_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_idtarea_Internalname, "Tr Actividades_IDTarea", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTrActividades_IDTarea), 13, 0, ".", "")), ((edtavCtractividades_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7cTrActividades_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV7cTrActividades_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_idtarea_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtractividades_idtarea_Visible, edtavCtractividades_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_nombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_nombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_nombrefilter_Internalname, "Tr Actividades_Nombre", "", "", lblLbltractividades_nombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13221_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_nombre_Internalname, "Tr Actividades_Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_nombre_Internalname, StringUtil.RTrim( AV8cTrActividades_Nombre), StringUtil.RTrim( context.localUtil.Format( AV8cTrActividades_Nombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_nombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtractividades_nombre_Visible, edtavCtractividades_nombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_fechainiciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_fechainiciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_fechainiciofilter_Internalname, "Tr Actividades_Fecha Inicio", "", "", lblLbltractividades_fechainiciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14221_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_fechainicio_Internalname, "Tr Actividades_Fecha Inicio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtractividades_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_fechainicio_Internalname, context.localUtil.Format(AV9cTrActividades_FechaInicio, "99/99/9999"), context.localUtil.Format( AV9cTrActividades_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_fechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtractividades_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_fechafinfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_fechafinfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_fechafinfilter_Internalname, "Tr Actividades_Fecha Fin", "", "", lblLbltractividades_fechafinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15221_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_fechafin_Internalname, "Tr Actividades_Fecha Fin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtractividades_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_fechafin_Internalname, context.localUtil.Format(AV10cTrActividades_FechaFin, "99/99/9999"), context.localUtil.Format( AV10cTrActividades_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_fechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtractividades_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_fechacreacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_fechacreacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_fechacreacionfilter_Internalname, "Tr Actividades_Fecha Creacion", "", "", lblLbltractividades_fechacreacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16221_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_fechacreacion_Internalname, "Tr Actividades_Fecha Creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtractividades_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_fechacreacion_Internalname, context.localUtil.Format(AV11cTrActividades_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV11cTrActividades_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_fechacreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtractividades_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTractividades_fechamodificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTractividades_fechamodificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltractividades_fechamodificacionfilter_Internalname, "Tr Actividades_Fecha Modificacion", "", "", lblLbltractividades_fechamodificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17221_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtractividades_fechamodificacion_Internalname, "Tr Actividades_Fecha Modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtractividades_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtractividades_fechamodificacion_Internalname, context.localUtil.Format(AV12cTrActividades_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV12cTrActividades_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtractividades_fechamodificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtractividades_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0040.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18221_client"+"'", TempTags, "", 2, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividades_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividades_IDTarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividades_Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividades_Fecha Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Actividades_Fecha Creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START222( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Tr Actividades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP220( ) ;
      }

      protected void WS222( )
      {
         START222( ) ;
         EVT222( ) ;
      }

      protected void EVT222( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A26TrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_ID_Internalname), ".", ","));
                              A25TrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrActividades_IDTarea_Internalname), ".", ","));
                              n25TrActividades_IDTarea = false;
                              A29TrActividades_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrActividades_FechaInicio_Internalname), 0));
                              n29TrActividades_FechaInicio = false;
                              A30TrActividades_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrActividades_FechaFin_Internalname), 0));
                              n30TrActividades_FechaFin = false;
                              A31TrActividades_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrActividades_FechaCreacion_Internalname), 0));
                              n31TrActividades_FechaCreacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctractividades_id Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRACTIVIDADES_ID"), ".", ",") != Convert.ToDecimal( AV6cTrActividades_ID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_idtarea Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRACTIVIDADES_IDTAREA"), ".", ",") != Convert.ToDecimal( AV7cTrActividades_IDTarea )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_nombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTRACTIVIDADES_NOMBRE"), AV8cTrActividades_Nombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_fechainicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRACTIVIDADES_FECHAINICIO"), 0) != AV9cTrActividades_FechaInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRACTIVIDADES_FECHAFIN"), 0) != AV10cTrActividades_FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_fechacreacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRACTIVIDADES_FECHACREACION"), 0) != AV11cTrActividades_FechaCreacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctractividades_fechamodificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRACTIVIDADES_FECHAMODIFICACION"), 0) != AV12cTrActividades_FechaModificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21222 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE222( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA222( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cTrActividades_ID ,
                                        long AV7cTrActividades_IDTarea ,
                                        String AV8cTrActividades_Nombre ,
                                        DateTime AV9cTrActividades_FechaInicio ,
                                        DateTime AV10cTrActividades_FechaFin ,
                                        DateTime AV11cTrActividades_FechaCreacion ,
                                        DateTime AV12cTrActividades_FechaModificacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF222( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRACTIVIDADES_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF222( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF222( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cTrActividades_IDTarea ,
                                                 AV8cTrActividades_Nombre ,
                                                 AV9cTrActividades_FechaInicio ,
                                                 AV10cTrActividades_FechaFin ,
                                                 AV11cTrActividades_FechaCreacion ,
                                                 AV12cTrActividades_FechaModificacion ,
                                                 A25TrActividades_IDTarea ,
                                                 A27TrActividades_Nombre ,
                                                 A29TrActividades_FechaInicio ,
                                                 A30TrActividades_FechaFin ,
                                                 A31TrActividades_FechaCreacion ,
                                                 A32TrActividades_FechaModificacion ,
                                                 AV6cTrActividades_ID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.STRING, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.STRING, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            } ) ;
            lV8cTrActividades_Nombre = StringUtil.PadR( StringUtil.RTrim( AV8cTrActividades_Nombre), 100, "%");
            /* Using cursor H00222 */
            pr_default.execute(0, new Object[] {AV6cTrActividades_ID, AV7cTrActividades_IDTarea, lV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A32TrActividades_FechaModificacion = H00222_A32TrActividades_FechaModificacion[0];
               n32TrActividades_FechaModificacion = H00222_n32TrActividades_FechaModificacion[0];
               A27TrActividades_Nombre = H00222_A27TrActividades_Nombre[0];
               n27TrActividades_Nombre = H00222_n27TrActividades_Nombre[0];
               A31TrActividades_FechaCreacion = H00222_A31TrActividades_FechaCreacion[0];
               n31TrActividades_FechaCreacion = H00222_n31TrActividades_FechaCreacion[0];
               A30TrActividades_FechaFin = H00222_A30TrActividades_FechaFin[0];
               n30TrActividades_FechaFin = H00222_n30TrActividades_FechaFin[0];
               A29TrActividades_FechaInicio = H00222_A29TrActividades_FechaInicio[0];
               n29TrActividades_FechaInicio = H00222_n29TrActividades_FechaInicio[0];
               A25TrActividades_IDTarea = H00222_A25TrActividades_IDTarea[0];
               n25TrActividades_IDTarea = H00222_n25TrActividades_IDTarea[0];
               A26TrActividades_ID = H00222_A26TrActividades_ID[0];
               /* Execute user event: Load */
               E20222 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB220( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes222( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRACTIVIDADES_ID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cTrActividades_IDTarea ,
                                              AV8cTrActividades_Nombre ,
                                              AV9cTrActividades_FechaInicio ,
                                              AV10cTrActividades_FechaFin ,
                                              AV11cTrActividades_FechaCreacion ,
                                              AV12cTrActividades_FechaModificacion ,
                                              A25TrActividades_IDTarea ,
                                              A27TrActividades_Nombre ,
                                              A29TrActividades_FechaInicio ,
                                              A30TrActividades_FechaFin ,
                                              A31TrActividades_FechaCreacion ,
                                              A32TrActividades_FechaModificacion ,
                                              AV6cTrActividades_ID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.STRING, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.STRING, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         } ) ;
         lV8cTrActividades_Nombre = StringUtil.PadR( StringUtil.RTrim( AV8cTrActividades_Nombre), 100, "%");
         /* Using cursor H00223 */
         pr_default.execute(1, new Object[] {AV6cTrActividades_ID, AV7cTrActividades_IDTarea, lV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion});
         GRID1_nRecordCount = H00223_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrActividades_ID, AV7cTrActividades_IDTarea, AV8cTrActividades_Nombre, AV9cTrActividades_FechaInicio, AV10cTrActividades_FechaFin, AV11cTrActividades_FechaCreacion, AV12cTrActividades_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP220( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19222 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtractividades_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtractividades_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRACTIVIDADES_ID");
               GX_FocusControl = edtavCtractividades_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTrActividades_ID = 0;
               AssignAttri("", false, "AV6cTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV6cTrActividades_ID), 13, 0));
            }
            else
            {
               AV6cTrActividades_ID = (long)(context.localUtil.CToN( cgiGet( edtavCtractividades_id_Internalname), ".", ","));
               AssignAttri("", false, "AV6cTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV6cTrActividades_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtractividades_idtarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtractividades_idtarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRACTIVIDADES_IDTAREA");
               GX_FocusControl = edtavCtractividades_idtarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTrActividades_IDTarea = 0;
               AssignAttri("", false, "AV7cTrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV7cTrActividades_IDTarea), 13, 0));
            }
            else
            {
               AV7cTrActividades_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtavCtractividades_idtarea_Internalname), ".", ","));
               AssignAttri("", false, "AV7cTrActividades_IDTarea", StringUtil.LTrimStr( (decimal)(AV7cTrActividades_IDTarea), 13, 0));
            }
            AV8cTrActividades_Nombre = cgiGet( edtavCtractividades_nombre_Internalname);
            AssignAttri("", false, "AV8cTrActividades_Nombre", AV8cTrActividades_Nombre);
            if ( context.localUtil.VCDate( cgiGet( edtavCtractividades_fechainicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Inicio"}), 1, "vCTRACTIVIDADES_FECHAINICIO");
               GX_FocusControl = edtavCtractividades_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTrActividades_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV9cTrActividades_FechaInicio", context.localUtil.Format(AV9cTrActividades_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV9cTrActividades_FechaInicio = context.localUtil.CToD( cgiGet( edtavCtractividades_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV9cTrActividades_FechaInicio", context.localUtil.Format(AV9cTrActividades_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtractividades_fechafin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Fin"}), 1, "vCTRACTIVIDADES_FECHAFIN");
               GX_FocusControl = edtavCtractividades_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTrActividades_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV10cTrActividades_FechaFin", context.localUtil.Format(AV10cTrActividades_FechaFin, "99/99/9999"));
            }
            else
            {
               AV10cTrActividades_FechaFin = context.localUtil.CToD( cgiGet( edtavCtractividades_fechafin_Internalname), 1);
               AssignAttri("", false, "AV10cTrActividades_FechaFin", context.localUtil.Format(AV10cTrActividades_FechaFin, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtractividades_fechacreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Creacion"}), 1, "vCTRACTIVIDADES_FECHACREACION");
               GX_FocusControl = edtavCtractividades_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTrActividades_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV11cTrActividades_FechaCreacion", context.localUtil.Format(AV11cTrActividades_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV11cTrActividades_FechaCreacion = context.localUtil.CToD( cgiGet( edtavCtractividades_fechacreacion_Internalname), 1);
               AssignAttri("", false, "AV11cTrActividades_FechaCreacion", context.localUtil.Format(AV11cTrActividades_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtractividades_fechamodificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Actividades_Fecha Modificacion"}), 1, "vCTRACTIVIDADES_FECHAMODIFICACION");
               GX_FocusControl = edtavCtractividades_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cTrActividades_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV12cTrActividades_FechaModificacion", context.localUtil.Format(AV12cTrActividades_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV12cTrActividades_FechaModificacion = context.localUtil.CToD( cgiGet( edtavCtractividades_fechamodificacion_Internalname), 1);
               AssignAttri("", false, "AV12cTrActividades_FechaModificacion", context.localUtil.Format(AV12cTrActividades_FechaModificacion, "99/99/9999"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRACTIVIDADES_ID"), ".", ",") != Convert.ToDecimal( AV6cTrActividades_ID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRACTIVIDADES_IDTAREA"), ".", ",") != Convert.ToDecimal( AV7cTrActividades_IDTarea )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTRACTIVIDADES_NOMBRE"), AV8cTrActividades_Nombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRACTIVIDADES_FECHAINICIO"), 1) != AV9cTrActividades_FechaInicio )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRACTIVIDADES_FECHAFIN"), 1) != AV10cTrActividades_FechaFin )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRACTIVIDADES_FECHACREACION"), 1) != AV11cTrActividades_FechaCreacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRACTIVIDADES_FECHAMODIFICACION"), 1) != AV12cTrActividades_FechaModificacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19222( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Selection List %1", "Tr Actividades", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20222( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21222( )
      {
         /* Enter Routine */
         AV13pTrActividades_ID = A26TrActividades_ID;
         AssignAttri("", false, "AV13pTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV13pTrActividades_ID), 13, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pTrActividades_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pTrActividades_ID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pTrActividades_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pTrActividades_ID", StringUtil.LTrimStr( (decimal)(AV13pTrActividades_ID), 13, 0));
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA222( ) ;
         WS222( ) ;
         WE222( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2022102021910", true, true);
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
         context.AddJavascriptSource("gx0040.js", "?2022102021910", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_84_idx;
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA_"+sGXsfl_84_idx;
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO_"+sGXsfl_84_idx;
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN_"+sGXsfl_84_idx;
         edtTrActividades_FechaCreacion_Internalname = "TRACTIVIDADES_FECHACREACION_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID_"+sGXsfl_84_fel_idx;
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA_"+sGXsfl_84_fel_idx;
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO_"+sGXsfl_84_fel_idx;
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN_"+sGXsfl_84_fel_idx;
         edtTrActividades_FechaCreacion_Internalname = "TRACTIVIDADES_FECHACREACION_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB220( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TrActividades_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A26TrActividades_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_IDTarea_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TrActividades_IDTarea), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A25TrActividades_IDTarea), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_IDTarea_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_FechaInicio_Internalname,context.localUtil.Format(A29TrActividades_FechaInicio, "99/99/9999"),context.localUtil.Format( A29TrActividades_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_FechaFin_Internalname,context.localUtil.Format(A30TrActividades_FechaFin, "99/99/9999"),context.localUtil.Format( A30TrActividades_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_FechaFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrActividades_FechaCreacion_Internalname,context.localUtil.Format(A31TrActividades_FechaCreacion, "99/99/9999"),context.localUtil.Format( A31TrActividades_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrActividades_FechaCreacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes222( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltractividades_idfilter_Internalname = "LBLTRACTIVIDADES_IDFILTER";
         edtavCtractividades_id_Internalname = "vCTRACTIVIDADES_ID";
         divTractividades_idfiltercontainer_Internalname = "TRACTIVIDADES_IDFILTERCONTAINER";
         lblLbltractividades_idtareafilter_Internalname = "LBLTRACTIVIDADES_IDTAREAFILTER";
         edtavCtractividades_idtarea_Internalname = "vCTRACTIVIDADES_IDTAREA";
         divTractividades_idtareafiltercontainer_Internalname = "TRACTIVIDADES_IDTAREAFILTERCONTAINER";
         lblLbltractividades_nombrefilter_Internalname = "LBLTRACTIVIDADES_NOMBREFILTER";
         edtavCtractividades_nombre_Internalname = "vCTRACTIVIDADES_NOMBRE";
         divTractividades_nombrefiltercontainer_Internalname = "TRACTIVIDADES_NOMBREFILTERCONTAINER";
         lblLbltractividades_fechainiciofilter_Internalname = "LBLTRACTIVIDADES_FECHAINICIOFILTER";
         edtavCtractividades_fechainicio_Internalname = "vCTRACTIVIDADES_FECHAINICIO";
         divTractividades_fechainiciofiltercontainer_Internalname = "TRACTIVIDADES_FECHAINICIOFILTERCONTAINER";
         lblLbltractividades_fechafinfilter_Internalname = "LBLTRACTIVIDADES_FECHAFINFILTER";
         edtavCtractividades_fechafin_Internalname = "vCTRACTIVIDADES_FECHAFIN";
         divTractividades_fechafinfiltercontainer_Internalname = "TRACTIVIDADES_FECHAFINFILTERCONTAINER";
         lblLbltractividades_fechacreacionfilter_Internalname = "LBLTRACTIVIDADES_FECHACREACIONFILTER";
         edtavCtractividades_fechacreacion_Internalname = "vCTRACTIVIDADES_FECHACREACION";
         divTractividades_fechacreacionfiltercontainer_Internalname = "TRACTIVIDADES_FECHACREACIONFILTERCONTAINER";
         lblLbltractividades_fechamodificacionfilter_Internalname = "LBLTRACTIVIDADES_FECHAMODIFICACIONFILTER";
         edtavCtractividades_fechamodificacion_Internalname = "vCTRACTIVIDADES_FECHAMODIFICACION";
         divTractividades_fechamodificacionfiltercontainer_Internalname = "TRACTIVIDADES_FECHAMODIFICACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrActividades_ID_Internalname = "TRACTIVIDADES_ID";
         edtTrActividades_IDTarea_Internalname = "TRACTIVIDADES_IDTAREA";
         edtTrActividades_FechaInicio_Internalname = "TRACTIVIDADES_FECHAINICIO";
         edtTrActividades_FechaFin_Internalname = "TRACTIVIDADES_FECHAFIN";
         edtTrActividades_FechaCreacion_Internalname = "TRACTIVIDADES_FECHACREACION";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtTrActividades_FechaCreacion_Jsonclick = "";
         edtTrActividades_FechaFin_Jsonclick = "";
         edtTrActividades_FechaInicio_Jsonclick = "";
         edtTrActividades_IDTarea_Jsonclick = "";
         edtTrActividades_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtractividades_fechamodificacion_Jsonclick = "";
         edtavCtractividades_fechamodificacion_Enabled = 1;
         edtavCtractividades_fechacreacion_Jsonclick = "";
         edtavCtractividades_fechacreacion_Enabled = 1;
         edtavCtractividades_fechafin_Jsonclick = "";
         edtavCtractividades_fechafin_Enabled = 1;
         edtavCtractividades_fechainicio_Jsonclick = "";
         edtavCtractividades_fechainicio_Enabled = 1;
         edtavCtractividades_nombre_Jsonclick = "";
         edtavCtractividades_nombre_Enabled = 1;
         edtavCtractividades_nombre_Visible = 1;
         edtavCtractividades_idtarea_Jsonclick = "";
         edtavCtractividades_idtarea_Enabled = 1;
         edtavCtractividades_idtarea_Visible = 1;
         edtavCtractividades_id_Jsonclick = "";
         edtavCtractividades_id_Enabled = 1;
         edtavCtractividades_id_Visible = 1;
         divTractividades_fechamodificacionfiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_fechacreacionfiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_fechafinfiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_fechainiciofiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_nombrefiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_idtareafiltercontainer_Class = "AdvancedContainerItem";
         divTractividades_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tr Actividades";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrActividades_ID',fld:'vCTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrActividades_IDTarea',fld:'vCTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV8cTrActividades_Nombre',fld:'vCTRACTIVIDADES_NOMBRE',pic:''},{av:'AV9cTrActividades_FechaInicio',fld:'vCTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV10cTrActividades_FechaFin',fld:'vCTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV11cTrActividades_FechaCreacion',fld:'vCTRACTIVIDADES_FECHACREACION',pic:''},{av:'AV12cTrActividades_FechaModificacion',fld:'vCTRACTIVIDADES_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18221',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRACTIVIDADES_IDFILTER.CLICK","{handler:'E11221',iparms:[{av:'divTractividades_idfiltercontainer_Class',ctrl:'TRACTIVIDADES_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_IDFILTER.CLICK",",oparms:[{av:'divTractividades_idfiltercontainer_Class',ctrl:'TRACTIVIDADES_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtractividades_id_Visible',ctrl:'vCTRACTIVIDADES_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRACTIVIDADES_IDTAREAFILTER.CLICK","{handler:'E12221',iparms:[{av:'divTractividades_idtareafiltercontainer_Class',ctrl:'TRACTIVIDADES_IDTAREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_IDTAREAFILTER.CLICK",",oparms:[{av:'divTractividades_idtareafiltercontainer_Class',ctrl:'TRACTIVIDADES_IDTAREAFILTERCONTAINER',prop:'Class'},{av:'edtavCtractividades_idtarea_Visible',ctrl:'vCTRACTIVIDADES_IDTAREA',prop:'Visible'}]}");
         setEventMetadata("LBLTRACTIVIDADES_NOMBREFILTER.CLICK","{handler:'E13221',iparms:[{av:'divTractividades_nombrefiltercontainer_Class',ctrl:'TRACTIVIDADES_NOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_NOMBREFILTER.CLICK",",oparms:[{av:'divTractividades_nombrefiltercontainer_Class',ctrl:'TRACTIVIDADES_NOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCtractividades_nombre_Visible',ctrl:'vCTRACTIVIDADES_NOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLTRACTIVIDADES_FECHAINICIOFILTER.CLICK","{handler:'E14221',iparms:[{av:'divTractividades_fechainiciofiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAINICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_FECHAINICIOFILTER.CLICK",",oparms:[{av:'divTractividades_fechainiciofiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAINICIOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRACTIVIDADES_FECHAFINFILTER.CLICK","{handler:'E15221',iparms:[{av:'divTractividades_fechafinfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAFINFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_FECHAFINFILTER.CLICK",",oparms:[{av:'divTractividades_fechafinfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAFINFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRACTIVIDADES_FECHACREACIONFILTER.CLICK","{handler:'E16221',iparms:[{av:'divTractividades_fechacreacionfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHACREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_FECHACREACIONFILTER.CLICK",",oparms:[{av:'divTractividades_fechacreacionfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHACREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRACTIVIDADES_FECHAMODIFICACIONFILTER.CLICK","{handler:'E17221',iparms:[{av:'divTractividades_fechamodificacionfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRACTIVIDADES_FECHAMODIFICACIONFILTER.CLICK",",oparms:[{av:'divTractividades_fechamodificacionfiltercontainer_Class',ctrl:'TRACTIVIDADES_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E21222',iparms:[{av:'A26TrActividades_ID',fld:'TRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pTrActividades_ID',fld:'vPTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrActividades_ID',fld:'vCTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrActividades_IDTarea',fld:'vCTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV8cTrActividades_Nombre',fld:'vCTRACTIVIDADES_NOMBRE',pic:''},{av:'AV9cTrActividades_FechaInicio',fld:'vCTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV10cTrActividades_FechaFin',fld:'vCTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV11cTrActividades_FechaCreacion',fld:'vCTRACTIVIDADES_FECHACREACION',pic:''},{av:'AV12cTrActividades_FechaModificacion',fld:'vCTRACTIVIDADES_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrActividades_ID',fld:'vCTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrActividades_IDTarea',fld:'vCTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV8cTrActividades_Nombre',fld:'vCTRACTIVIDADES_NOMBRE',pic:''},{av:'AV9cTrActividades_FechaInicio',fld:'vCTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV10cTrActividades_FechaFin',fld:'vCTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV11cTrActividades_FechaCreacion',fld:'vCTRACTIVIDADES_FECHACREACION',pic:''},{av:'AV12cTrActividades_FechaModificacion',fld:'vCTRACTIVIDADES_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrActividades_ID',fld:'vCTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrActividades_IDTarea',fld:'vCTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV8cTrActividades_Nombre',fld:'vCTRACTIVIDADES_NOMBRE',pic:''},{av:'AV9cTrActividades_FechaInicio',fld:'vCTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV10cTrActividades_FechaFin',fld:'vCTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV11cTrActividades_FechaCreacion',fld:'vCTRACTIVIDADES_FECHACREACION',pic:''},{av:'AV12cTrActividades_FechaModificacion',fld:'vCTRACTIVIDADES_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrActividades_ID',fld:'vCTRACTIVIDADES_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrActividades_IDTarea',fld:'vCTRACTIVIDADES_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'AV8cTrActividades_Nombre',fld:'vCTRACTIVIDADES_NOMBRE',pic:''},{av:'AV9cTrActividades_FechaInicio',fld:'vCTRACTIVIDADES_FECHAINICIO',pic:''},{av:'AV10cTrActividades_FechaFin',fld:'vCTRACTIVIDADES_FECHAFIN',pic:''},{av:'AV11cTrActividades_FechaCreacion',fld:'vCTRACTIVIDADES_FECHACREACION',pic:''},{av:'AV12cTrActividades_FechaModificacion',fld:'vCTRACTIVIDADES_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAINICIO","{handler:'Validv_Ctractividades_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAFIN","{handler:'Validv_Ctractividades_fechafin',iparms:[]");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHACREACION","{handler:'Validv_Ctractividades_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAMODIFICACION","{handler:'Validv_Ctractividades_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_CTRACTIVIDADES_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tractividades_fechacreacion',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV8cTrActividades_Nombre = "";
         AV9cTrActividades_FechaInicio = DateTime.MinValue;
         AV10cTrActividades_FechaFin = DateTime.MinValue;
         AV11cTrActividades_FechaCreacion = DateTime.MinValue;
         AV12cTrActividades_FechaModificacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltractividades_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltractividades_idtareafilter_Jsonclick = "";
         lblLbltractividades_nombrefilter_Jsonclick = "";
         lblLbltractividades_fechainiciofilter_Jsonclick = "";
         lblLbltractividades_fechafinfilter_Jsonclick = "";
         lblLbltractividades_fechacreacionfilter_Jsonclick = "";
         lblLbltractividades_fechamodificacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A29TrActividades_FechaInicio = DateTime.MinValue;
         A30TrActividades_FechaFin = DateTime.MinValue;
         A31TrActividades_FechaCreacion = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV8cTrActividades_Nombre = "";
         A27TrActividades_Nombre = "";
         A32TrActividades_FechaModificacion = DateTime.MinValue;
         H00222_A32TrActividades_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H00222_n32TrActividades_FechaModificacion = new bool[] {false} ;
         H00222_A27TrActividades_Nombre = new String[] {""} ;
         H00222_n27TrActividades_Nombre = new bool[] {false} ;
         H00222_A31TrActividades_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H00222_n31TrActividades_FechaCreacion = new bool[] {false} ;
         H00222_A30TrActividades_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00222_n30TrActividades_FechaFin = new bool[] {false} ;
         H00222_A29TrActividades_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00222_n29TrActividades_FechaInicio = new bool[] {false} ;
         H00222_A25TrActividades_IDTarea = new long[1] ;
         H00222_n25TrActividades_IDTarea = new bool[] {false} ;
         H00222_A26TrActividades_ID = new long[1] ;
         H00223_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0040__default(),
            new Object[][] {
                new Object[] {
               H00222_A32TrActividades_FechaModificacion, H00222_n32TrActividades_FechaModificacion, H00222_A27TrActividades_Nombre, H00222_n27TrActividades_Nombre, H00222_A31TrActividades_FechaCreacion, H00222_n31TrActividades_FechaCreacion, H00222_A30TrActividades_FechaFin, H00222_n30TrActividades_FechaFin, H00222_A29TrActividades_FechaInicio, H00222_n29TrActividades_FechaInicio,
               H00222_A25TrActividades_IDTarea, H00222_n25TrActividades_IDTarea, H00222_A26TrActividades_ID
               }
               , new Object[] {
               H00223_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtractividades_id_Enabled ;
      private int edtavCtractividades_id_Visible ;
      private int edtavCtractividades_idtarea_Enabled ;
      private int edtavCtractividades_idtarea_Visible ;
      private int edtavCtractividades_nombre_Visible ;
      private int edtavCtractividades_nombre_Enabled ;
      private int edtavCtractividades_fechainicio_Enabled ;
      private int edtavCtractividades_fechafin_Enabled ;
      private int edtavCtractividades_fechacreacion_Enabled ;
      private int edtavCtractividades_fechamodificacion_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTrActividades_ID ;
      private long AV7cTrActividades_IDTarea ;
      private long AV13pTrActividades_ID ;
      private long A26TrActividades_ID ;
      private long A25TrActividades_IDTarea ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTractividades_idfiltercontainer_Class ;
      private String divTractividades_idtareafiltercontainer_Class ;
      private String divTractividades_nombrefiltercontainer_Class ;
      private String divTractividades_fechainiciofiltercontainer_Class ;
      private String divTractividades_fechafinfiltercontainer_Class ;
      private String divTractividades_fechacreacionfiltercontainer_Class ;
      private String divTractividades_fechamodificacionfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_84_idx="0001" ;
      private String AV8cTrActividades_Nombre ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTractividades_idfiltercontainer_Internalname ;
      private String lblLbltractividades_idfilter_Internalname ;
      private String lblLbltractividades_idfilter_Jsonclick ;
      private String edtavCtractividades_id_Internalname ;
      private String TempTags ;
      private String edtavCtractividades_id_Jsonclick ;
      private String divTractividades_idtareafiltercontainer_Internalname ;
      private String lblLbltractividades_idtareafilter_Internalname ;
      private String lblLbltractividades_idtareafilter_Jsonclick ;
      private String edtavCtractividades_idtarea_Internalname ;
      private String edtavCtractividades_idtarea_Jsonclick ;
      private String divTractividades_nombrefiltercontainer_Internalname ;
      private String lblLbltractividades_nombrefilter_Internalname ;
      private String lblLbltractividades_nombrefilter_Jsonclick ;
      private String edtavCtractividades_nombre_Internalname ;
      private String edtavCtractividades_nombre_Jsonclick ;
      private String divTractividades_fechainiciofiltercontainer_Internalname ;
      private String lblLbltractividades_fechainiciofilter_Internalname ;
      private String lblLbltractividades_fechainiciofilter_Jsonclick ;
      private String edtavCtractividades_fechainicio_Internalname ;
      private String edtavCtractividades_fechainicio_Jsonclick ;
      private String divTractividades_fechafinfiltercontainer_Internalname ;
      private String lblLbltractividades_fechafinfilter_Internalname ;
      private String lblLbltractividades_fechafinfilter_Jsonclick ;
      private String edtavCtractividades_fechafin_Internalname ;
      private String edtavCtractividades_fechafin_Jsonclick ;
      private String divTractividades_fechacreacionfiltercontainer_Internalname ;
      private String lblLbltractividades_fechacreacionfilter_Internalname ;
      private String lblLbltractividades_fechacreacionfilter_Jsonclick ;
      private String edtavCtractividades_fechacreacion_Internalname ;
      private String edtavCtractividades_fechacreacion_Jsonclick ;
      private String divTractividades_fechamodificacionfiltercontainer_Internalname ;
      private String lblLbltractividades_fechamodificacionfilter_Internalname ;
      private String lblLbltractividades_fechamodificacionfilter_Jsonclick ;
      private String edtavCtractividades_fechamodificacion_Internalname ;
      private String edtavCtractividades_fechamodificacion_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtTrActividades_ID_Internalname ;
      private String edtTrActividades_IDTarea_Internalname ;
      private String edtTrActividades_FechaInicio_Internalname ;
      private String edtTrActividades_FechaFin_Internalname ;
      private String edtTrActividades_FechaCreacion_Internalname ;
      private String scmdbuf ;
      private String lV8cTrActividades_Nombre ;
      private String A27TrActividades_Nombre ;
      private String AV14ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_84_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrActividades_ID_Jsonclick ;
      private String edtTrActividades_IDTarea_Jsonclick ;
      private String edtTrActividades_FechaInicio_Jsonclick ;
      private String edtTrActividades_FechaFin_Jsonclick ;
      private String edtTrActividades_FechaCreacion_Jsonclick ;
      private DateTime AV9cTrActividades_FechaInicio ;
      private DateTime AV10cTrActividades_FechaFin ;
      private DateTime AV11cTrActividades_FechaCreacion ;
      private DateTime AV12cTrActividades_FechaModificacion ;
      private DateTime A29TrActividades_FechaInicio ;
      private DateTime A30TrActividades_FechaFin ;
      private DateTime A31TrActividades_FechaCreacion ;
      private DateTime A32TrActividades_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n25TrActividades_IDTarea ;
      private bool n29TrActividades_FechaInicio ;
      private bool n30TrActividades_FechaFin ;
      private bool n31TrActividades_FechaCreacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool n32TrActividades_FechaModificacion ;
      private bool n27TrActividades_Nombre ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV17Linkselection_GXI ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00222_A32TrActividades_FechaModificacion ;
      private bool[] H00222_n32TrActividades_FechaModificacion ;
      private String[] H00222_A27TrActividades_Nombre ;
      private bool[] H00222_n27TrActividades_Nombre ;
      private DateTime[] H00222_A31TrActividades_FechaCreacion ;
      private bool[] H00222_n31TrActividades_FechaCreacion ;
      private DateTime[] H00222_A30TrActividades_FechaFin ;
      private bool[] H00222_n30TrActividades_FechaFin ;
      private DateTime[] H00222_A29TrActividades_FechaInicio ;
      private bool[] H00222_n29TrActividades_FechaInicio ;
      private long[] H00222_A25TrActividades_IDTarea ;
      private bool[] H00222_n25TrActividades_IDTarea ;
      private long[] H00222_A26TrActividades_ID ;
      private long[] H00223_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTrActividades_ID ;
      private GXWebForm Form ;
   }

   public class gx0040__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00222( IGxContext context ,
                                             long AV7cTrActividades_IDTarea ,
                                             String AV8cTrActividades_Nombre ,
                                             DateTime AV9cTrActividades_FechaInicio ,
                                             DateTime AV10cTrActividades_FechaFin ,
                                             DateTime AV11cTrActividades_FechaCreacion ,
                                             DateTime AV12cTrActividades_FechaModificacion ,
                                             long A25TrActividades_IDTarea ,
                                             String A27TrActividades_Nombre ,
                                             DateTime A29TrActividades_FechaInicio ,
                                             DateTime A30TrActividades_FechaFin ,
                                             DateTime A31TrActividades_FechaCreacion ,
                                             DateTime A32TrActividades_FechaModificacion ,
                                             long AV6cTrActividades_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [10] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrActividades_FechaModificacion], [TrActividades_Nombre], [TrActividades_FechaCreacion], [TrActividades_FechaFin], [TrActividades_FechaInicio], [TrActividades_IDTarea], [TrActividades_ID]";
         sFromString = " FROM TABLERO.[TrActividades]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrActividades_ID] >= @AV6cTrActividades_ID)";
         if ( ! (0==AV7cTrActividades_IDTarea) )
         {
            sWhereString = sWhereString + " and ([TrActividades_IDTarea] >= @AV7cTrActividades_IDTarea)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cTrActividades_Nombre)) )
         {
            sWhereString = sWhereString + " and ([TrActividades_Nombre] like @lV8cTrActividades_Nombre)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrActividades_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaInicio] >= @AV9cTrActividades_FechaInicio)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrActividades_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaFin] >= @AV10cTrActividades_FechaFin)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrActividades_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaCreacion] >= @AV11cTrActividades_FechaCreacion)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTrActividades_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaModificacion] >= @AV12cTrActividades_FechaModificacion)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrActividades_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00223( IGxContext context ,
                                             long AV7cTrActividades_IDTarea ,
                                             String AV8cTrActividades_Nombre ,
                                             DateTime AV9cTrActividades_FechaInicio ,
                                             DateTime AV10cTrActividades_FechaFin ,
                                             DateTime AV11cTrActividades_FechaCreacion ,
                                             DateTime AV12cTrActividades_FechaModificacion ,
                                             long A25TrActividades_IDTarea ,
                                             String A27TrActividades_Nombre ,
                                             DateTime A29TrActividades_FechaInicio ,
                                             DateTime A30TrActividades_FechaFin ,
                                             DateTime A31TrActividades_FechaCreacion ,
                                             DateTime A32TrActividades_FechaModificacion ,
                                             long AV6cTrActividades_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrActividades]";
         scmdbuf = scmdbuf + " WHERE ([TrActividades_ID] >= @AV6cTrActividades_ID)";
         if ( ! (0==AV7cTrActividades_IDTarea) )
         {
            sWhereString = sWhereString + " and ([TrActividades_IDTarea] >= @AV7cTrActividades_IDTarea)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cTrActividades_Nombre)) )
         {
            sWhereString = sWhereString + " and ([TrActividades_Nombre] like @lV8cTrActividades_Nombre)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrActividades_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaInicio] >= @AV9cTrActividades_FechaInicio)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrActividades_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaFin] >= @AV10cTrActividades_FechaFin)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrActividades_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaCreacion] >= @AV11cTrActividades_FechaCreacion)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cTrActividades_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrActividades_FechaModificacion] >= @AV12cTrActividades_FechaModificacion)";
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00222(context, (long)dynConstraints[0] , (String)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (String)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00223(context, (long)dynConstraints[0] , (String)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (String)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00222 ;
          prmH00222 = new Object[] {
          new Object[] {"@AV6cTrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrActividades_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@lV8cTrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV9cTrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cTrActividades_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00223 ;
          prmH00223 = new Object[] {
          new Object[] {"@AV6cTrActividades_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrActividades_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@lV8cTrActividades_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV9cTrActividades_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrActividades_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrActividades_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV12cTrActividades_FechaModificacion",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00222", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00222,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00223", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00223,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
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
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[10]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[11]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[12]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[13]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[14]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[15]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[16]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[17]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[18]);
                }
                if ( (short)parms[9] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[19]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[8]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[9]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[10]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[13]);
                }
                return;
       }
    }

 }

}
