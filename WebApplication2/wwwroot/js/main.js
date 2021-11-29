﻿require.config({
    baseUrl: 'js',
    paths: {

        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text",
        dataservice: "Service/DataService"
    }
});


require(['knockout', 'text'], (ko, vm) => {

    ko.components.register("Search-for-movies", {
        viewModel: { require: "Components/SearchBar/SearchBar" },
        template: { require: "text!Components/SearchBar/SearchBar.html" }
    });

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});