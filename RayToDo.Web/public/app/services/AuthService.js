angular.module('app').factory('AuthService', ['$http', '$q', '$window', 'localStorageService', 'api', function ($http, $q, $window, localStorageService, api) {
        
        var authServiceFactory = {};
        
        var _authentication = {
            isAuth: false,
            userName: ""
        };
        
        var _register = function (data) {
            
            _logout();
            
            return $http.post(api.url + 'api/account/register', data).then(function (response) {
                return response;
            });

        };
        
        var _login = function (data) {
            
            var data = "grant_type=password&username=" + data.userName + "&password=" + data.password;
            
            var deferred = $q.defer();
            
            $http.post(api.url + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                
                console.log(response);
                
                localStorageService.set('authData', { token: response.access_token, userName: response.userName });
                
                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                
                
                deferred.resolve(response);

            }).error(function (err, status) {
                _logout();
                deferred.reject(err);
            });
            
            return deferred.promise;

        };
        
        var _logout = function () {
            
            localStorageService.remove('authData');
            
            _authentication.isAuth = false;
            _authentication.userName = "";

        };
        
        var _fillAuthData = function () {
            
            var authData = localStorageService.get('authData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
            }

        }
        
        authServiceFactory.register = _register;
        authServiceFactory.login = _login;
        authServiceFactory.logout = _logout;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;
        
        return authServiceFactory;
    }]);