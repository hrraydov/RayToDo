(function () {
    angular.module('app').directive('registerPanel', registerPanel);
    
    function registerPanel() {
        var controller = function ($scope, AuthService) {
            
            $scope.registerSuccess = false;
            $scope.registerFail = false;
            $scope.message = '';
            $scope.errors = [];
            
            $scope.data = {
                username: '',
                email: '',
                password: '',
                password_confirm: ''
            };
            
            $scope.register = function (form) {
                if (form.$valid) {
                    AuthService.register({
                        UserName: $scope.data.username,
                        Email: $scope.data.email,
                        Password: $scope.data.password,
                        ConfirmPassword: $scope.data.password_confirm
                    }).then(function (response) {
                        $scope.registerSuccess = true;
                        $scope.registerFail = false;
                        $scope.message = 'You have registered successfully';
                    }, function (response) {
                        var errors = [];
                        for (var key in response.data.ModelState) {
                            for (var i = 0; i < response.data.ModelState[key].length; i++) {
                                errors.push(response.data.ModelState[key][i]);
                            }
                        }
                        $scope.registerFail = true;
                        $scope.registerSuccess = false;
                        $scope.errors = errors;
                    });
                } else {
                    $scope.registerFail = true;
                }
            };
        };
        controller.$inject = ['$scope', 'AuthService'];

        return {
            restrict: 'E',
            templateUrl: 'app/directives/register-panel/registerPanel.html',
            scope: {},
            controller: controller
        };
    }
})();