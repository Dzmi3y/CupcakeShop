import { Route, Routes } from "react-router-dom";
import { NotFoundPage } from "./pages/NotFoundPage";
import { HomePage } from "./pages/HomePage";
import { CatalogPage } from "./pages/CatalogPage";
import { OrderPage } from "./pages/OrderPage";
import { ProductPage } from "./pages/ProductPage";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" Component={HomePage} />
        <Route path="/catalog" Component={CatalogPage} />
        <Route path="/order" Component={OrderPage} />
        <Route path="/product" Component={ProductPage} />
        <Route Component={NotFoundPage} />
      </Routes>
    </>
  );
}

export default App;
