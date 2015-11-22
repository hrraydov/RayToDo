(function () {
    angular.module('app').controller('ListsCreateCtrl', ListsCreateCtrl);
    
    function ListsCreateCtrl($scope, $uibModalInstance, ListService) {
        
        $scope.data = {
            name: "",
            description: "",
        };
        
        $scope.create = function () {
            ListService.create({
                Name: $scope.data.name,
                Description: $scope.data.description,
                Type: "Personal"
            }).then(function (data) {
                console.log(data);
                $uibModalInstance.close(data);
            }, function (data) {
                console.log(data);
            });
        };
        
        $scope.close = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
    
    ListsCreateCtrl.$inject = ['$scope', '$uibModalInstance', 'ListService'];
})();