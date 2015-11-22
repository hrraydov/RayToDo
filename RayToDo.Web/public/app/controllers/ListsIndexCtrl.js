(function () {
    angular.module('app').controller('ListsIndexCtrl', ListsIndexCtrl);
    
    function ListsIndexCtrl($scope, $uibModal, ListService) {

        $scope.lists = [];
        
        $scope.init = function () {
            ListService.getAll().then(function (lists) {
                $scope.lists = lists;
            });
        };
        
        $scope.create = function () {
            var modal = $uibModal.open({
                templateUrl: 'partials/lists/create.html',
                controller: 'ListsCreateCtrl'
            });
            console.log(modal);
        };
    }
    
    ListsIndexCtrl.$inject = ['$scope', '$uibModal', 'ListService'];
})();