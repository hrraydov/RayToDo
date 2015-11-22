(function () {
    angular.module('app').config(loadingBar);

    function loadingBar(cfpLoadingBarProvider) { 
        cfpLoadingBarProvider.includeSpinner = false;
    }

    loadingBar.$inject = ['cfpLoadingBarProvider'];
})();