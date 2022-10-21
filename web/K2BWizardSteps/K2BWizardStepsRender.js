function K2BWizardSteps(JQuery) {
	this.WizardSteps;
	this.SelectedStep = 1;
	this.CurrentStep = 1;
	this.WizardCompleted;
	this._$ = JQuery;
	

	// Databinding for property GridOrders
	this.SetWizardSteps = function (data) {
		///UserCodeRegionStart:[SetGridOrders] (do not remove this comment.)
		this.WizardSteps = data;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property GridOrders
	this.GetWizardSteps = function () {
		///UserCodeRegionStart:[GetGridOrders] (do not remove this comment.)
		return this.WizardSteps;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.SetSelectedStep = function (data) {
		///UserCodeRegionStart:[SetGridOrders] (do not remove this comment.)
		this.SelectedStep = data;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property GridOrders
	this.GetSelectedStep = function () {
		///UserCodeRegionStart:[GetGridOrders] (do not remove this comment.)
		return this.SelectedStep;
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	
	
		this.SetCurrentStep = function (data) {
		///UserCodeRegionStart:[SetGridOrders] (do not remove this comment.)
		this.CurrentStep = parseInt(data);
		///UserCodeRegionEnd: (do not remove this comment.)
	}


	// Databinding for property GridOrders
	this.GetCurrentStep = function () {
		///UserCodeRegionStart:[GetGridOrders] (do not remove this comment.)
		return this.CurrentStep;
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	
	
	
	
	
	
	
	
	this.show = function () 
	{
			
			var _wizard = this;
			if (!this.IsPostBack) 
			{
				var mainNode = _wizard._$("<div>").addClass("K2BWizardSteps").attr('id', _wizard.ControlName);
				var ulNode = _wizard._$('<ul>').attr('id', "main" + _wizard.ControlName);
				mainNode.append(ulNode);
			}
			else
			{
				_wizard._$("#" + _wizard.DesignContainerName).off("click");
				var mainNode = _wizard._$(_wizard._$.find("div#" + _wizard.ControlName));
				var ulNode = _wizard._$(_wizard._$.find("ul#main" + _wizard.ControlName ));
				ulNode.empty();
			}
			var nextStepAllowClick = false; 
			var isWizardCompleted = _wizard.CurrentStep > _wizard.WizardSteps.length || _wizard.WizardCompleted;
			if (isWizardCompleted)
			{
				mainNode.addClass("WizardCompleted");
			}


			for(var i =0;i<_wizard.WizardSteps.length;i++)
			{
				
				var li = _wizard._$("<li>");
				if (_wizard.CurrentStep == i+1)
				{
					li.addClass("StepSelected");
					if (isWizardCompleted)
						li.addClass("StepCompleted");
				}
				else if (_wizard.CurrentStep > i+1)
				{
					li.addClass("StepCompleted");
					if ((_wizard.WizardSteps[i].Available) && (!isWizardCompleted))
						li.addClass("StepAllowClick");
				}
				else if (((_wizard.CurrentStep == i) || nextStepAllowClick)   && (!isWizardCompleted))					//Next selectable element
				{
					if ((_wizard.WizardSteps[i].Available))
					{
						nextStepAllowClick = false;
						li.addClass("StepAllowClick");
					}
					else
					{
						nextStepAllowClick = true;
					}
				
				}
				
				if (!_wizard.WizardSteps[i].Available)
				{
					li.addClass("NotAvailableStep");
				}
				mystep = i+1;
				var liControlName = _wizard.ControlName + "Step" + mystep
				li.attr("id",  liControlName);
				
				var innerDiv = _wizard._$("<div>");
				li.append(innerDiv);
				 
				var spanNumber = _wizard._$("<span>").addClass("WizardNumber");
				
				if ((isWizardCompleted) && (mystep ==_wizard.WizardSteps.length ))
				{
					li.addClass("StepSelected");
					
				}
				else
				{
					spanNumber.text(_wizard.WizardSteps[i].StepNumber);
				}
				
				
				
				var spanTitle = _wizard._$("<span>").addClass("WizardTitle");
				
				spanTitle.text(_wizard.WizardSteps[i].StepName);
				innerDiv.append(spanNumber);
				innerDiv.append(spanTitle);
				ulNode.append(li);
				
				
				_wizard._$("#"+ _wizard.DesignContainerName).on("click", "li#" + liControlName + ".StepAllowClick", {currentStep:i+1}, function (e) {
					if (typeof(_wizard.WizardStepClicked) == 'function')
						_wizard.SelectedStep = e.data.currentStep;
						_wizard.WizardStepClicked();
				});
		
				
				
					
				
			
		
		}
		
		if (!this.IsPostBack) 
		{
			this.setHtml(mainNode[0].outerHTML);
		}
		

		
	}

}
