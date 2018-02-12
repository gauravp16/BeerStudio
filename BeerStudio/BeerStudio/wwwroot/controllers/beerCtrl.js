angular.module('beerApp').
    controller('beerCtrl', function ($scope, $routeParams, beerService) {
        beerService.getBeerDetails($routeParams.id).then(function (response) {
            $scope.name = response.data.name;
            $scope.description = response.data.description;
            $scope.organic = response.data.isOrganic === 'Y' ? 'Organic' : 'Not Organic';
            $scope.abv = response.data.abv;
        });


    });