gx.evt.autoSkip=!1;gx.define("wpactualizartablero",!1,function(){var n,t;this.ServerClass="wpactualizartablero";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A1TrGestionTableros_ID=gx.fn.getControlValue("TRGESTIONTABLEROS_ID");this.AV5TrGestionTableros_ID=gx.fn.getControlValue("vTRGESTIONTABLEROS_ID");this.A2TrGestionTableros_Nombre=gx.fn.getControlValue("TRGESTIONTABLEROS_NOMBRE");this.A5TrGestionTableros_Descripcion=gx.fn.getControlValue("TRGESTIONTABLEROS_DESCRIPCION");this.A6TrGestionTableros_Comentario=gx.fn.getControlValue("TRGESTIONTABLEROS_COMENTARIO");this.A9TrGestionTableros_TipoTablero=gx.fn.getIntegerValue("TRGESTIONTABLEROS_TIPOTABLERO",",");this.A3TrGestionTableros_FechaInicio=gx.fn.getDateValue("TRGESTIONTABLEROS_FECHAINICIO");this.A4TrGestionTableros_FechaFin=gx.fn.getDateValue("TRGESTIONTABLEROS_FECHAFIN");this.A7TrGestionTableros_FechaCreacion=gx.fn.getDateValue("TRGESTIONTABLEROS_FECHACREACION");this.A8TrGestionTableros_FechaModificacion=gx.fn.getDateValue("TRGESTIONTABLEROS_FECHAMODIFICACION");this.A10TrGestionTableros_Estado=gx.fn.getIntegerValue("TRGESTIONTABLEROS_ESTADO",",");this.AV29ConfirmationRequired=gx.fn.getControlValue("vCONFIRMATIONREQUIRED");this.AV26CrearTablero_SDT=gx.fn.getControlValue("vCREARTABLERO_SDT");this.AV30ConfirmationSubId=gx.fn.getControlValue("vCONFIRMATIONSUBID");this.AV30ConfirmationSubId=gx.fn.getControlValue("vCONFIRMATIONSUBID")};this.Validv_Trgestiontableros_fechainicio=function(){return this.validCliEvt("Validv_Trgestiontableros_fechainicio",0,function(){try{var n=gx.util.balloon.getNew("vTRGESTIONTABLEROS_FECHAINICIO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV17TrGestionTableros_FechaInicio)===0||new gx.date.gxdate(this.AV17TrGestionTableros_FechaInicio).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Inicio fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Trgestiontableros_fechafin=function(){return this.validCliEvt("Validv_Trgestiontableros_fechafin",0,function(){try{var n=gx.util.balloon.getNew("vTRGESTIONTABLEROS_FECHAFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV18TrGestionTableros_FechaFin)===0||new gx.date.gxdate(this.AV18TrGestionTableros_FechaFin).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Fin fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Trgestiontableros_fechacreacion=function(){return this.validCliEvt("Validv_Trgestiontableros_fechacreacion",0,function(){try{var n=gx.util.balloon.getNew("vTRGESTIONTABLEROS_FECHACREACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV21TrGestionTableros_FechaCreacion)===0||new gx.date.gxdate(this.AV21TrGestionTableros_FechaCreacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Creacion del tablero fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Trgestiontableros_fechamodificacion=function(){return this.validCliEvt("Validv_Trgestiontableros_fechamodificacion",0,function(){try{var n=gx.util.balloon.getNew("vTRGESTIONTABLEROS_FECHAMODIFICACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV24TrGestionTableros_FechaModificacion)===0||new gx.date.gxdate(this.AV24TrGestionTableros_FechaModificacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Modificacion del tablero fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Trgestiontableros_estado=function(){return this.validCliEvt("Validv_Trgestiontableros_estado",0,function(){try{var n=gx.util.balloon.getNew("vTRGESTIONTABLEROS_ESTADO");if(this.AnyError=0,!(this.AV25TrGestionTableros_Estado==1||this.AV25TrGestionTableros_Estado==2||this.AV25TrGestionTableros_Estado==3||this.AV25TrGestionTableros_Estado==4||this.AV25TrGestionTableros_Estado==5))try{n.setError("Campo Estado del tablero fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s112_client=function(){};this.s132_client=function(){};this.s142_client=function(){this.AV29ConfirmationRequired=!0};this.e161v1_client=function(){return this.clearMessages(),this.AV30ConfirmationSubId="",gx.fn.setCtrlProperty("TABLECONDITIONALCONFIRM","Visible",!1),this.refreshOutputs([{av:"AV30ConfirmationSubId",fld:"vCONFIRMATIONSUBID",pic:""},{av:'gx.fn.getCtrlProperty("TABLECONDITIONALCONFIRM","Visible")',ctrl:"TABLECONDITIONALCONFIRM",prop:"Visible"}]),gx.$.Deferred().resolve()};this.e131v2_client=function(){return this.executeServerEvent("'E_MODIFICARTABLERO'",!1,null,!1,!1)};this.e141v2_client=function(){return this.executeServerEvent("'CONFIRMYES'",!1,null,!1,!1)};this.e171v2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e181v2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,89,90,91,92,95,98,101,102,105,108,110,111,112];this.GXLastCtrlId=112;this.K2BCONTROLBEAUTIFY1Container=gx.uc.getNew(this,113,34,"K2BControlBeautify","K2BCONTROLBEAUTIFY1Container","K2bcontrolbeautify1","K2BCONTROLBEAUTIFY1");t=this.K2BCONTROLBEAUTIFY1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("UpdateCheckboxes","Updatecheckboxes",!0,"bool");t.setProp("UpdateSelects","Updateselects",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"SECTION2",grid:0};n[10]={id:10,fld:"TITLE",format:0,grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"CONTENTTABLE",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"GROUP",grid:0};n[20]={id:20,fld:"MAINGROUPRESPONSIVETABLE_GROUP",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"ATTRIBUTESCONTAINERTABLE_ATTRIBUTES",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TEXTBLOCK",format:0,grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_NOMBRE",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"char",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_NOMBRE",gxz:"ZV13TrGestionTableros_Nombre",gxold:"OV13TrGestionTableros_Nombre",gxvar:"AV13TrGestionTableros_Nombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13TrGestionTableros_Nombre=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13TrGestionTableros_Nombre=n)},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_NOMBRE",gx.O.AV13TrGestionTableros_Nombre,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13TrGestionTableros_Nombre=this.val())},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_NOMBRE")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"TEXTBLOCK1",format:0,grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_DESCRIPCION",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_DESCRIPCION",gxz:"ZV14TrGestionTableros_Descripcion",gxold:"OV14TrGestionTableros_Descripcion",gxvar:"AV14TrGestionTableros_Descripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14TrGestionTableros_Descripcion=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14TrGestionTableros_Descripcion=n)},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_DESCRIPCION",gx.O.AV14TrGestionTableros_Descripcion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14TrGestionTableros_Descripcion=this.val())},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_DESCRIPCION")},nac:gx.falseFn};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"TEXTBLOCK2",format:0,grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_COMENTARIO",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_COMENTARIO",gxz:"ZV15TrGestionTableros_Comentario",gxold:"OV15TrGestionTableros_Comentario",gxvar:"AV15TrGestionTableros_Comentario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15TrGestionTableros_Comentario=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15TrGestionTableros_Comentario=n)},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_COMENTARIO",gx.O.AV15TrGestionTableros_Comentario,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15TrGestionTableros_Comentario=this.val())},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_COMENTARIO")},nac:gx.falseFn};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAINICIO",grid:0};n[54]={id:54,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_FECHAINICIOFIELDCONTAINER",grid:0};n[55]={id:55,fld:"TRGESTIONTABLEROS_FECHAINICIO_VAR_LEFTTEXT",format:0,grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Trgestiontableros_fechainicio,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_FECHAINICIO",gxz:"ZV17TrGestionTableros_FechaInicio",gxold:"OV17TrGestionTableros_FechaInicio",gxvar:"AV17TrGestionTableros_FechaInicio",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[57],ip:[57],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_FECHAINICIO",gx.O.AV17TrGestionTableros_FechaInicio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_FECHAINICIO")},nac:gx.falseFn};n[58]={id:58,fld:"TRGESTIONTABLEROS_FECHAFIN_VAR_LEFTTEXT",format:0,grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Trgestiontableros_fechafin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_FECHAFIN",gxz:"ZV18TrGestionTableros_FechaFin",gxold:"OV18TrGestionTableros_FechaFin",gxvar:"AV18TrGestionTableros_FechaFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[60],ip:[60],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV18TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_FECHAFIN",gx.O.AV18TrGestionTableros_FechaFin,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV18TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_FECHAFIN")},nac:gx.falseFn};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_FECHACREACION",grid:0};n[64]={id:64,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_FECHACREACIONFIELDCONTAINER",grid:0};n[65]={id:65,fld:"TRGESTIONTABLEROS_FECHACREACION_VAR_LEFTTEXT",format:0,grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Trgestiontableros_fechacreacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_FECHACREACION",gxz:"ZV21TrGestionTableros_FechaCreacion",gxold:"OV21TrGestionTableros_FechaCreacion",gxvar:"AV21TrGestionTableros_FechaCreacion",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[67],ip:[67],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21TrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21TrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_FECHACREACION",gx.O.AV21TrGestionTableros_FechaCreacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV21TrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_FECHACREACION")},nac:gx.falseFn};n[68]={id:68,fld:"TRGESTIONTABLEROS_FECHAMODIFICACION_VAR_LEFTTEXT",format:0,grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Trgestiontableros_fechamodificacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_FECHAMODIFICACION",gxz:"ZV24TrGestionTableros_FechaModificacion",gxold:"OV24TrGestionTableros_FechaModificacion",gxvar:"AV24TrGestionTableros_FechaModificacion",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[70],ip:[70],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24TrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24TrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_FECHAMODIFICACION",gx.O.AV24TrGestionTableros_FechaModificacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV24TrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vTRGESTIONTABLEROS_FECHAMODIFICACION")},nac:gx.falseFn};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_TIPOTABLERO",grid:0};n[74]={id:74,fld:"TABLE_CONTAINER_TRGESTIONTABLEROS_TIPOTABLEROFIELDCONTAINER",grid:0};n[75]={id:75,fld:"TRGESTIONTABLEROS_TIPOTABLERO_VAR_LEFTTEXT",format:0,grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_TIPOTABLERO",gxz:"ZV16TrGestionTableros_TipoTablero",gxold:"OV16TrGestionTableros_TipoTablero",gxvar:"AV16TrGestionTableros_TipoTablero",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16TrGestionTableros_TipoTablero=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16TrGestionTableros_TipoTablero=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTRGESTIONTABLEROS_TIPOTABLERO",gx.O.AV16TrGestionTableros_TipoTablero,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16TrGestionTableros_TipoTablero=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTRGESTIONTABLEROS_TIPOTABLERO",",")},nac:gx.falseFn};n[78]={id:78,fld:"TRGESTIONTABLEROS_ESTADO_VAR_LEFTTEXT",format:0,grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Trgestiontableros_estado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRGESTIONTABLEROS_ESTADO",gxz:"ZV25TrGestionTableros_Estado",gxold:"OV25TrGestionTableros_Estado",gxvar:"AV25TrGestionTableros_Estado",ucs:[],op:[80],ip:[80],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV25TrGestionTableros_Estado=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV25TrGestionTableros_Estado=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vTRGESTIONTABLEROS_ESTADO",gx.O.AV25TrGestionTableros_Estado)},c2v:function(){this.val()!==undefined&&(gx.O.AV25TrGestionTableros_Estado=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTRGESTIONTABLEROS_ESTADO",",")},nac:gx.falseFn};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"RESPONSIVETABLE_CONTAINERNODE_ACTIONS",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"ACTIONSCONTAINERTABLELEFT_ACTIONS",grid:0};n[89]={id:89,fld:"MODIFICARTABLERO",grid:0,evt:"e131v2_client"};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"TABLECONDITIONALCONFIRM",grid:0};n[95]={id:95,fld:"SECTION_CONDCONF_DIALOG",grid:0};n[98]={id:98,fld:"SECTION_CONDCONF_DIALOG_INNER",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCONFIRMMESSAGE",gxz:"ZV28ConfirmMessage",gxold:"OV28ConfirmMessage",gxvar:"AV28ConfirmMessage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28ConfirmMessage=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28ConfirmMessage=n)},v2c:function(){gx.fn.setControlValue("vCONFIRMMESSAGE",gx.O.AV28ConfirmMessage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV28ConfirmMessage=this.val())},val:function(){return gx.fn.getControlValue("vCONFIRMMESSAGE")},nac:gx.falseFn};n[105]={id:105,fld:"CONFIRM_HIDDEN_ACTIONSTABLE",grid:0};n[108]={id:108,fld:"I_BUTTONCONFIRMYES",grid:0,evt:"e141v2_client"};n[110]={id:110,fld:"I_BUTTONCONFIRMNO",grid:0,evt:"e161v1_client"};n[111]={id:111,fld:"",grid:0};n[112]={id:112,fld:"",grid:0};this.AV13TrGestionTableros_Nombre="";this.ZV13TrGestionTableros_Nombre="";this.OV13TrGestionTableros_Nombre="";this.AV14TrGestionTableros_Descripcion="";this.ZV14TrGestionTableros_Descripcion="";this.OV14TrGestionTableros_Descripcion="";this.AV15TrGestionTableros_Comentario="";this.ZV15TrGestionTableros_Comentario="";this.OV15TrGestionTableros_Comentario="";this.AV17TrGestionTableros_FechaInicio=gx.date.nullDate();this.ZV17TrGestionTableros_FechaInicio=gx.date.nullDate();this.OV17TrGestionTableros_FechaInicio=gx.date.nullDate();this.AV18TrGestionTableros_FechaFin=gx.date.nullDate();this.ZV18TrGestionTableros_FechaFin=gx.date.nullDate();this.OV18TrGestionTableros_FechaFin=gx.date.nullDate();this.AV21TrGestionTableros_FechaCreacion=gx.date.nullDate();this.ZV21TrGestionTableros_FechaCreacion=gx.date.nullDate();this.OV21TrGestionTableros_FechaCreacion=gx.date.nullDate();this.AV24TrGestionTableros_FechaModificacion=gx.date.nullDate();this.ZV24TrGestionTableros_FechaModificacion=gx.date.nullDate();this.OV24TrGestionTableros_FechaModificacion=gx.date.nullDate();this.AV16TrGestionTableros_TipoTablero=0;this.ZV16TrGestionTableros_TipoTablero=0;this.OV16TrGestionTableros_TipoTablero=0;this.AV25TrGestionTableros_Estado=0;this.ZV25TrGestionTableros_Estado=0;this.OV25TrGestionTableros_Estado=0;this.AV28ConfirmMessage="";this.ZV28ConfirmMessage="";this.OV28ConfirmMessage="";this.AV13TrGestionTableros_Nombre="";this.AV14TrGestionTableros_Descripcion="";this.AV15TrGestionTableros_Comentario="";this.AV17TrGestionTableros_FechaInicio=gx.date.nullDate();this.AV18TrGestionTableros_FechaFin=gx.date.nullDate();this.AV21TrGestionTableros_FechaCreacion=gx.date.nullDate();this.AV24TrGestionTableros_FechaModificacion=gx.date.nullDate();this.AV16TrGestionTableros_TipoTablero=0;this.AV25TrGestionTableros_Estado=0;this.AV28ConfirmMessage="";this.AV5TrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.A1TrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.A2TrGestionTableros_Nombre="";this.A5TrGestionTableros_Descripcion="";this.A6TrGestionTableros_Comentario="";this.A9TrGestionTableros_TipoTablero=0;this.A3TrGestionTableros_FechaInicio=gx.date.nullDate();this.A4TrGestionTableros_FechaFin=gx.date.nullDate();this.A7TrGestionTableros_FechaCreacion=gx.date.nullDate();this.A8TrGestionTableros_FechaModificacion=gx.date.nullDate();this.A10TrGestionTableros_Estado=0;this.AV29ConfirmationRequired=!1;this.AV26CrearTablero_SDT={TrGestionTableros_ID:"00000000-0000-0000-0000-000000000000",TrGestionTableros_Nombre:"",TrGestionTableros_Descripcion:"",TrGestionTableros_Comentario:"",TrGestionTableros_TipoTablero:0,TrGestionTableros_FechaInicio:gx.date.nullDate(),TrGestionTableros_FechaFin:gx.date.nullDate(),TrGestionTableros_FechaCreacion:gx.date.nullDate(),TrGestionTableros_FechaModificacion:gx.date.nullDate(),TrGestionTableros_Estado:0};this.AV30ConfirmationSubId="";this.Events={e131v2_client:["'E_MODIFICARTABLERO'",!0],e141v2_client:["'CONFIRMYES'",!0],e171v2_client:["ENTER",!0],e181v2_client:["CANCEL",!0],e161v1_client:["'CONFIRMNO'",!1]};this.EvtParms.REFRESH=[[{av:"A1TrGestionTableros_ID",fld:"TRGESTIONTABLEROS_ID",pic:""},{av:"A2TrGestionTableros_Nombre",fld:"TRGESTIONTABLEROS_NOMBRE",pic:""},{av:"A5TrGestionTableros_Descripcion",fld:"TRGESTIONTABLEROS_DESCRIPCION",pic:""},{av:"A6TrGestionTableros_Comentario",fld:"TRGESTIONTABLEROS_COMENTARIO",pic:""},{av:"A9TrGestionTableros_TipoTablero",fld:"TRGESTIONTABLEROS_TIPOTABLERO",pic:"ZZZ9"},{av:"A3TrGestionTableros_FechaInicio",fld:"TRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"A4TrGestionTableros_FechaFin",fld:"TRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"A7TrGestionTableros_FechaCreacion",fld:"TRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"A8TrGestionTableros_FechaModificacion",fld:"TRGESTIONTABLEROS_FECHAMODIFICACION",pic:""},{av:"A10TrGestionTableros_Estado",fld:"TRGESTIONTABLEROS_ESTADO",pic:"ZZZ9"},{av:"AV5TrGestionTableros_ID",fld:"vTRGESTIONTABLEROS_ID",pic:"",hsh:!0},{av:"AV21TrGestionTableros_FechaCreacion",fld:"vTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV24TrGestionTableros_FechaModificacion",fld:"vTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[{av:"AV29ConfirmationRequired",fld:"vCONFIRMATIONREQUIRED",pic:""},{av:"AV13TrGestionTableros_Nombre",fld:"vTRGESTIONTABLEROS_NOMBRE",pic:""},{av:"AV14TrGestionTableros_Descripcion",fld:"vTRGESTIONTABLEROS_DESCRIPCION",pic:""},{av:"AV15TrGestionTableros_Comentario",fld:"vTRGESTIONTABLEROS_COMENTARIO",pic:""},{av:"AV16TrGestionTableros_TipoTablero",fld:"vTRGESTIONTABLEROS_TIPOTABLERO",pic:"ZZZ9"},{av:"AV17TrGestionTableros_FechaInicio",fld:"vTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV18TrGestionTableros_FechaFin",fld:"vTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV21TrGestionTableros_FechaCreacion",fld:"vTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV24TrGestionTableros_FechaModificacion",fld:"vTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""},{ctrl:"vTRGESTIONTABLEROS_ESTADO"},{av:"AV25TrGestionTableros_Estado",fld:"vTRGESTIONTABLEROS_ESTADO",pic:"ZZZ9"}]];this.EvtParms.START=[[],[{av:'gx.fn.getCtrlProperty("TABLECONDITIONALCONFIRM","Visible")',ctrl:"TABLECONDITIONALCONFIRM",prop:"Visible"}]];this.EvtParms["'E_MODIFICARTABLERO'"]=[[{av:"AV29ConfirmationRequired",fld:"vCONFIRMATIONREQUIRED",pic:""},{av:"AV5TrGestionTableros_ID",fld:"vTRGESTIONTABLEROS_ID",pic:"",hsh:!0},{av:"AV26CrearTablero_SDT",fld:"vCREARTABLERO_SDT",pic:""},{av:"AV13TrGestionTableros_Nombre",fld:"vTRGESTIONTABLEROS_NOMBRE",pic:""},{av:"AV14TrGestionTableros_Descripcion",fld:"vTRGESTIONTABLEROS_DESCRIPCION",pic:""},{av:"AV15TrGestionTableros_Comentario",fld:"vTRGESTIONTABLEROS_COMENTARIO",pic:""},{av:"AV16TrGestionTableros_TipoTablero",fld:"vTRGESTIONTABLEROS_TIPOTABLERO",pic:"ZZZ9"},{av:"AV17TrGestionTableros_FechaInicio",fld:"vTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV18TrGestionTableros_FechaFin",fld:"vTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV21TrGestionTableros_FechaCreacion",fld:"vTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV24TrGestionTableros_FechaModificacion",fld:"vTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""},{ctrl:"vTRGESTIONTABLEROS_ESTADO"},{av:"AV25TrGestionTableros_Estado",fld:"vTRGESTIONTABLEROS_ESTADO",pic:"ZZZ9"}],[{av:"AV28ConfirmMessage",fld:"vCONFIRMMESSAGE",pic:""},{av:"AV30ConfirmationSubId",fld:"vCONFIRMATIONSUBID",pic:""},{av:'gx.fn.getCtrlProperty("TABLECONDITIONALCONFIRM","Visible")',ctrl:"TABLECONDITIONALCONFIRM",prop:"Visible"},{av:"AV29ConfirmationRequired",fld:"vCONFIRMATIONREQUIRED",pic:""},{av:"AV26CrearTablero_SDT",fld:"vCREARTABLERO_SDT",pic:""}]];this.EvtParms["'CONFIRMNO'"]=[[],[{av:"AV30ConfirmationSubId",fld:"vCONFIRMATIONSUBID",pic:""},{av:'gx.fn.getCtrlProperty("TABLECONDITIONALCONFIRM","Visible")',ctrl:"TABLECONDITIONALCONFIRM",prop:"Visible"}]];this.EvtParms["'CONFIRMYES'"]=[[{av:"AV30ConfirmationSubId",fld:"vCONFIRMATIONSUBID",pic:""},{av:"AV5TrGestionTableros_ID",fld:"vTRGESTIONTABLEROS_ID",pic:"",hsh:!0},{av:"AV26CrearTablero_SDT",fld:"vCREARTABLERO_SDT",pic:""},{av:"AV13TrGestionTableros_Nombre",fld:"vTRGESTIONTABLEROS_NOMBRE",pic:""},{av:"AV14TrGestionTableros_Descripcion",fld:"vTRGESTIONTABLEROS_DESCRIPCION",pic:""},{av:"AV15TrGestionTableros_Comentario",fld:"vTRGESTIONTABLEROS_COMENTARIO",pic:""},{av:"AV16TrGestionTableros_TipoTablero",fld:"vTRGESTIONTABLEROS_TIPOTABLERO",pic:"ZZZ9"},{av:"AV17TrGestionTableros_FechaInicio",fld:"vTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV18TrGestionTableros_FechaFin",fld:"vTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV21TrGestionTableros_FechaCreacion",fld:"vTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV24TrGestionTableros_FechaModificacion",fld:"vTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""},{ctrl:"vTRGESTIONTABLEROS_ESTADO"},{av:"AV25TrGestionTableros_Estado",fld:"vTRGESTIONTABLEROS_ESTADO",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("TABLECONDITIONALCONFIRM","Visible")',ctrl:"TABLECONDITIONALCONFIRM",prop:"Visible"},{av:"AV26CrearTablero_SDT",fld:"vCREARTABLERO_SDT",pic:""}]];this.EvtParms.VALIDV_TRGESTIONTABLEROS_FECHAINICIO=[[],[]];this.EvtParms.VALIDV_TRGESTIONTABLEROS_FECHAFIN=[[],[]];this.EvtParms.VALIDV_TRGESTIONTABLEROS_FECHACREACION=[[],[]];this.EvtParms.VALIDV_TRGESTIONTABLEROS_FECHAMODIFICACION=[[],[]];this.EvtParms.VALIDV_TRGESTIONTABLEROS_ESTADO=[[],[]];this.setVCMap("A1TrGestionTableros_ID","TRGESTIONTABLEROS_ID",0,"guid",4,0);this.setVCMap("AV5TrGestionTableros_ID","vTRGESTIONTABLEROS_ID",0,"guid",4,0);this.setVCMap("A2TrGestionTableros_Nombre","TRGESTIONTABLEROS_NOMBRE",0,"char",100,0);this.setVCMap("A5TrGestionTableros_Descripcion","TRGESTIONTABLEROS_DESCRIPCION",0,"vchar",2097152,0);this.setVCMap("A6TrGestionTableros_Comentario","TRGESTIONTABLEROS_COMENTARIO",0,"vchar",2097152,0);this.setVCMap("A9TrGestionTableros_TipoTablero","TRGESTIONTABLEROS_TIPOTABLERO",0,"int",4,0);this.setVCMap("A3TrGestionTableros_FechaInicio","TRGESTIONTABLEROS_FECHAINICIO",0,"date",8,0);this.setVCMap("A4TrGestionTableros_FechaFin","TRGESTIONTABLEROS_FECHAFIN",0,"date",8,0);this.setVCMap("A7TrGestionTableros_FechaCreacion","TRGESTIONTABLEROS_FECHACREACION",0,"date",8,0);this.setVCMap("A8TrGestionTableros_FechaModificacion","TRGESTIONTABLEROS_FECHAMODIFICACION",0,"date",8,0);this.setVCMap("A10TrGestionTableros_Estado","TRGESTIONTABLEROS_ESTADO",0,"int",4,0);this.setVCMap("AV29ConfirmationRequired","vCONFIRMATIONREQUIRED",0,"boolean",4,0);this.setVCMap("AV26CrearTablero_SDT","vCREARTABLERO_SDT",0,"CrearTablero_SDT",0,0);this.setVCMap("AV30ConfirmationSubId","vCONFIRMATIONSUBID",0,"char",20,0);this.setVCMap("AV30ConfirmationSubId","vCONFIRMATIONSUBID",0,"char",20,0);this.Initialize()});gx.wi(function(){gx.createParentObj(wpactualizartablero)})