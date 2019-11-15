//Find fraction
function fract(n) {
    return Number(String(n).split('.')[1] || 0);
}
function integral(n) {
    return Number(String(n).split('.')[0] || 0);
}