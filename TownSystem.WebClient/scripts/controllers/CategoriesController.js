'use strict';

galleryApp.controller('CategoriesController', function CategoriesController($scope, $location) {
    $scope.categories = {
        nature: [
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Stara Zagora',
                likes: 13,
                category: 'Nature',
                id: 1
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Blagoevgrad',
                likes: 27,
                category: 'Nature',
                id: 2
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Sliven',
                likes: 3,
                category: 'Nature',
                id: 3
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Dobrich',
                likes: 19,
                category: 'Nature',
                id: 4
            }],
        historicalMonuments: [
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Pernik',
                likes: 23,
                category: 'Historical monuments',
                id: 1
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Plovdiv',
                likes: 27,
                category: 'Historical monuments',
                id: 2
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Kjustendil',
                likes: 23,
                category: 'Historical monuments',
                id: 3
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Burgas',
                likes: 19,
                category: 'Historical monuments',
                id: 4
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Burgas',
                likes: 27,
                category: 'Historical monuments',
                id: 5
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Sofia',
                likes: 23,
                category: 'Historical monuments',
                id: 6
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Ruse',
                likes: 19,
                category: 'Historical monuments',
                id: 7
            }]
    }

    $scope.openPost = function (id, townName) {
        var town = townName.toLowerCase().replace(' ', '');
        $location.path('/towns/' + town + '/' + (100 + id));
    };
});