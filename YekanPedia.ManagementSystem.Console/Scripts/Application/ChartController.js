function sparklineBar(id, values, height, barWidth, barColor, barSpacing) {
    $('.' + id).sparkline(values, {
        type: 'bar',
        height: height,
        barWidth: barWidth,
        barColor: barColor,
        barSpacing: barSpacing
    })
}
function sparklineLine(id, values, width, height, lineColor, fillColor, lineWidth, maxSpotColor, minSpotColor, spotColor, spotRadius, hSpotColor, hLineColor) {
    $('.' + id).sparkline(values, {
        type: 'line',
        width: width,
        height: height,
        lineColor: lineColor,
        fillColor: fillColor,
        lineWidth: lineWidth,
        maxSpotColor: maxSpotColor,
        minSpotColor: minSpotColor,
        spotColor: spotColor,
        spotRadius: spotRadius,
        highlightSpotColor: hSpotColor,
        highlightLineColor: hLineColor
    });
}
function sparklinePie(id, values, width, height, sliceColors) {
    $('.' + id).sparkline(values, {
        type: 'pie',
        width: width,
        height: height,
        sliceColors: sliceColors,
        offset: 0,
        borderWidth: 0
    });
}
function easyPieChart(id, trackColor, scaleColor, barColor, lineWidth, lineCap, size) {
    $('.' + id).easyPieChart({
        trackColor: trackColor,
        scaleColor: scaleColor,
        barColor: barColor,
        lineWidth: lineWidth,
        lineCap: lineCap,
        size: size
    });
}





