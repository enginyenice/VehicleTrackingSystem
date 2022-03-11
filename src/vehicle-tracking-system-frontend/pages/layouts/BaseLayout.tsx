// eslint-disable-next-line @next/next/no-html-link-for-pages
import Head from "next/head";
import Link from "next/link";
export default function BaseLayout(props: any) {
  return (
    <>
      <Head>
        <meta charSet="utf-8" />
        <meta
          name="viewport"
          content="width=device-width, initial-scale=1, shrink-to-fit=no"
        />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Vehicle Tracking System</title>
        {/* Favicon*/}
        <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
      </Head>
      {/* Responsive navbar*/}
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div className="container">
          <Link href="/">
            <a className="navbar-brand">Vehicle Tracking System</a>
          </Link>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon" />
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link aria-current="page" href="/login" passHref={true}>
                  <a className="nav-link active">Login</a>
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      {/* Page content*/}
      <div className="container mt-4">{props.children}</div>
      {/* Bootstrap core JS*/}
      {/* Core theme JS*/}
    </>
  );
}
