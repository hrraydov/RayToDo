(function () {
    angular.module('app').directive('navigation', navigation);
    
    function navigation() {
        
        function controller($scope, $location, AuthService) {
            $scope.navCollapsed = true;
            $scope.auth = AuthService.authentication;
            
            $scope.toggleCollapse = function () {
                $scope.navCollapsed = !$scope.navCollapsed;
            };
            
            $scope.logout = function () {
                AuthService.logout();
                $location.path('/');
            };
        }
        controller.$inject = ['$scope', '$location', 'AuthService'];
        
        return {
            restrict: 'E',
            templateUrl: 'app/directives/navigation/navigation.html',
            scope: {},
            controller: controller
        };
    }
})();