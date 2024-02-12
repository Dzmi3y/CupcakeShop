import { Route, Routes } from "react-router-dom";
import { NotFoundPage } from "./pages/NotFoundPage";
import { HomePage } from "./pages/HomePage";
import { CatalogPage } from "./pages/CatalogPage";
import { OrderPage } from "./pages/OrderPage";
import { ProductPage } from "./pages/ProductPage";
import { Header } from "./components/Header";
import { Footer } from "./components/Footer";
import { Container } from "./components/Container";

function App() {
  return (
    <>
      <Header />
        <Routes>
          <Route path="/" Component={HomePage} />
          <Route path="/catalog" Component={CatalogPage} />
          <Route path="/order" Component={OrderPage} />
          <Route path="/product" Component={ProductPage} />
          <Route Component={NotFoundPage} />
        </Routes>
      <Footer />
    </>
  );
}

export default App;
