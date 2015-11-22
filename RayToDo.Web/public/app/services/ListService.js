(function () {
    angular.module('app').factory('ListService', ListService);
    
    function ListService($http, $q, api) {
        var listServiceFactory = {};
        
        var _getAll = function () {
            var deferred = $q.defer();
            
            $http.get(api.url + 'api/lists')
            .success(function (lists) {
                deferred.resolve(lists);
            })
            .error(function (err) {
                deferred.reject(err);
            });
            
            return deferred.promise;
        };
        
        var _create = function (data) {
            var deferred = $q.defer();
            
            $http.post(api.url + 'api/lists', data)
            .success(function (response) {
                deferred.resolve(response);
            })
            .error(function (response) {
                deferred.reject(response);
            });
            
            return deferred.promise;
        };
        
        listServiceFactory.getAll = _getAll;
        listServiceFactory.create = _create;
        
        return listServiceFactory;
    }
    
    ListService.$inject = ['$http', '$q', 'api'];
})();