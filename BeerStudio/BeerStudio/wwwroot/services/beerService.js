﻿angular.module('beerApp')
.factory('beerService', function ($http) {
    return {
        getAllBeers: function () {
            return $http.get('http://localhost:1974/api/beers');
        }
    };
});
