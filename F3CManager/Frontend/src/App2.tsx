import { Provider } from "react-redux"
import store from "./store/store"
import Test from "./components/test"

function App() {
    

    return (
        <Provider store={store}>
            F3C Manager
            <Test />
        </Provider>
    )
}

export default App