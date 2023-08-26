/**
 * @param {string} text
 */
export function setOrderFormHeadline(text) {
    const element = document.getElementById("orderFormHeadlineText");
    if (element) {
        element.innerHTML = text;
    }
}
