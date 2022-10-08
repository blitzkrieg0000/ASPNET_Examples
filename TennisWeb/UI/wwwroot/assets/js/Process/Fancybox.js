Fancybox.bind("[data-fancybox='gallery']", {
    infinite: false,
    Image: {
        Panzoom: {
            zoomFriction: 0.7,
            maxScale: function () {
                return 5;
            },
        },
    },
});