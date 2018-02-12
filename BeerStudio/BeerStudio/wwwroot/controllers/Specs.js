describe('Controllers', function () {

    beforeEach(angular.mock.module('beerApp'));

    var $httpBackend, scope, $controller, controller;
    var data = [{ "id": "123", "name": "Some beer", "abv": "12" },
        { "id": "456", "name": "Nice beer", "abv": "15" }];

    beforeEach(angular.mock.inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    describe('MainCtrl', function () {
        beforeEach(inject(function ($rootScope, _$httpBackend_, beerService, $controller) {
            $httpBackend = _$httpBackend_;
            $httpBackend.whenGET('main.html').respond(200, '');

            $httpBackend.expectGET('http://localhost:1974/api/beers').respond(200, data);

            scope = $rootScope.$new();

            controller = $controller('mainCtrl', { $scope: scope, beerService: beerService});
            spyOn(beerService, 'getAllBeers').and.callThrough();

            $httpBackend.flush();
            scope.$root.$digest();
        }));

        describe('When the controller is loaded', function () {
            it('Should return get all beers', function () {
                expect(scope.beers).not.toBeNull();
                expect(scope.beers).toEqual(data);
            });

            it('Should set properties other than "id" as sortable', function () {
                expect(scope.sortItems).not.toBeNull();
                expect(scope.sortItems).toEqual([{ label: 'name', isSelected : true },
                    { label: 'abv', isSelected : false }]);
            });
        });

        describe('When user selects sorting order', function () {
            it('Should sort all the beers in the list', function () {
                scope.sortBy({ label: 'abv', isSelected: false });

                expect(scope.sortItems).toEqual([{ label: 'name', isSelected: false },
                { label: 'abv', isSelected: true }]);
            });
        });
    });

    
});