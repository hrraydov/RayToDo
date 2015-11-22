(function () {
    angular.module('app').directive('loginPanel', loginPanel);
    
    function loginPanel() {
        var controller = function ($scope, $location, AuthService) {
            
            $scope.loginFail = false;
            $scope.errors = [];
            
            $scope.data = {
                username: '',
                password: ''
            };
            
            $scope.login = function (form) {
                if (form.$valid) {
                    AuthService.login({
                        userName: $scope.data.username,
                        password: $scope.data.password
                    }).then(function (response) {
                        $location.path('/');
                    }, function (response) {
                        var errors = [];
                        errors.push(response.error_description);
                        $scope.loginFail = true;
                        $scope.errors = errors;
                    });
                } else {
                    $scope.loginFail = true;
                }
            };
        };
        controller.$inject = ['$scope', '$location', 'AuthService'];
        
        return {
            restrict: 'E',
            templateUrl: 'app/directives/login-panel/loginPanel.html',
            scope: {},
            controller: controller
        };
    }
})();