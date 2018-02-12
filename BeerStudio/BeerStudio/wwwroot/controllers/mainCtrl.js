angular.module('beerApp').
    controller("mainCtrl", function ($scope, beerService) {
        $scope.sortItems = [];

        beerService.getAllBeers().then(function (response) {
            $scope.beers = response.data;

            for (var key in $scope.beers[0]) {
                if (key !== 'id' && $scope.beers[0].hasOwnProperty(key)) {
                    $scope.sortItems.push({ label: key, isSelected: false });
                }
            }

            $scope.selected = $scope.selected || $scope.sortItems[0];
            $scope.selected.isSelected = true;
        });

        $scope.open = function (id) {
            $location.path("beers/" + id);
        };

        $scope.sortBy = function (item) {
            _.each($scope.sortItems, function (i) {
                i.isSelected = false;
            });

            item.isSelected = true;
            $scope.selected = item;
        };
    });
