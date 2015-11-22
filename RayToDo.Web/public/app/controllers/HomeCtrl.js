(function () {
    angular.module('app').controller('HomeCtrl', HomeCtrl);
    
    function HomeCtrl($scope, AuthService) {
        $scope.auth = AuthService.authentication;
    }
    
    HomeCtrl.$inject = ['$scope', 'AuthService'];
})();