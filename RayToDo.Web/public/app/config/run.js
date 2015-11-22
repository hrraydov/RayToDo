(function () {
    angular.module('app').run(run);
    
    function run(AuthService) {
        AuthService.fillAuthData();
    }
    
    run.$inject = ['AuthService'];
})();