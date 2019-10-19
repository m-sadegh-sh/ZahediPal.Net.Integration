namespace ZahediPal.Net.Integration.Core.Endpoint.Parameters {
    public enum PaymentOpResult : short {
        Succeeded = 2,
        Failed = 1,
        Unkndown = 0,
        AmountRequired = -1,
        PinRequired = -2,
        CallbackRequired = -3,
        AmountInvalid = -4,
        AmountNegative = -5,
        PinEmptyOrInvalid = -6,
        GatewyIpMismatched = -7,
        TransactionIdRequired = -8,
        TransactionIdInvalid = -9,
        PinTransactionIdMismatched = -10,
        AmountMismatched = -11,
        BankEmptyOrInvalid = -12
    }
}