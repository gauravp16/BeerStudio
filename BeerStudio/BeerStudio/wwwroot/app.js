var app = angular.module('beerApp', ["ngRoute"]);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/beers/:id', {
            templateUrl: "beer.html",
            controller: "beerCtrl"
        })
        .otherwise({
            templateUrl: "main.html",
            controller: "mainCtrl"
        });
});