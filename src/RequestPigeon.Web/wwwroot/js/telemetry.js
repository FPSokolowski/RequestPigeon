const VISIT_ENDPOINT = "https://sokolowskifilip.pl/api/visit";
const PUBLINK_VISIT_ENDPOINT = "https://sokolowskifilip.pl/api/publink-visit";

export function getTelemetryEndpoint(location = window.location) {
  const normalizedPath = location.pathname.replace(/\/+$/, "").toLowerCase();

  return normalizedPath === "/publink"
    ? PUBLINK_VISIT_ENDPOINT
    : VISIT_ENDPOINT;
}

export function buildTelemetryPayload({
  location = window.location,
  documentRef = document,
  navigatorRef = navigator,
} = {}) {
  return {
    fullUrl: location.href,
    path: location.pathname + location.search,
    referrer: documentRef.referrer,
    language: documentRef.documentElement.lang || navigatorRef.language,
    clientUserAgent: navigatorRef.userAgent,
  };
}

export function sendVisitTelemetry({
  fetchRef = window.fetch.bind(window),
  location = window.location,
  documentRef = document,
  navigatorRef = navigator,
} = {}) {
  const endpoint = getTelemetryEndpoint(location);
  const body = JSON.stringify(
    buildTelemetryPayload({ location, documentRef, navigatorRef }),
  );

  return fetchRef(endpoint, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body,
    keepalive: true,
    credentials: "omit",
  }).catch(() => {});
}

sendVisitTelemetry();
