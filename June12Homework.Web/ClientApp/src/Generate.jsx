import { useState } from "react"
import axios from "axios"

const Generate = () => {

    const [amount, setAmount] = useState('')
    const onGenerateClick = async () => {
        // window.location.href = `/api/people/generate`,  {
        //   params: {
        //     amount: amountValue
        //   }
        // };

        window.location.href = `/api/people/generate?amount=${amount}`;
    }

    const onInputChange = e => {
      setAmount(e.target.value)
    }
    return(<>
        <div className="d-flex vh-100" style={{ marginTop: "-70px" }}>
          <div className="d-flex w-100 justify-content-center align-self-center">
            <div className="row">
              <input
                type="text"
                className="form-control-lg"
                placeholder="Amount"
                onChange={onInputChange}
                value={amount}
              />
            </div>
            <div className="row">
              <div className="col-md-4 offset-md-2">
                <button className="btn btn-primary btn-lg" onClick={onGenerateClick}>
                  Generate
                </button>
              </div>
            </div>
          </div>
        </div>
      </>
      )
}

export default Generate