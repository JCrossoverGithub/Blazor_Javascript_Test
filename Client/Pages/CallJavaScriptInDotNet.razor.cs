using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Javascript_Test.Client.Pages
{
    public partial class CallJavaScriptInDotNet
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;
        private string _registrationResult;
        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/jsExamples.js");
        }

        public async Task ShowAlertWindow()
        {
            await _jsModule.InvokeVoidAsync("showAlert", "JS function called from .NET");
        }

        private async Task RegisterEmail() =>
            _registrationResult = await _jsModule.InvokeAsync<string>("emailRegistration", "Please provide your email");
    }
}
