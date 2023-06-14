import Layout from './Layout';
import { Route, Routes } from 'react-router-dom';
import Home from './Home';
import Upload from './Upload';
import Generate from './Generate';

const App = () => {
    return(<Layout>
        <Routes>
            <Route exact path='/' element={<Home/>}/>
            <Route exact path='/upload' element={<Upload/>}/>
            <Route exact path='generate' element={<Generate/>}/>
        </Routes>
    </Layout>)
}

export default App;