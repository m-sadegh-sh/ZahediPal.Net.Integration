using ZahediPal.Net.Integration.Core.Endpoint.Parameters;

namespace ZahediPal.Net.Integration.Core.Helpers {
    public static class UiHelpers {
        public static string ToHumanReadable(PaymentOpResult result) {
            switch (result) {
                case PaymentOpResult.Succeeded:
                    return "موفق";
                case PaymentOpResult.Failed:
                    return "ناموفق";
                case PaymentOpResult.AmountRequired:
                    return "Amount نمیتواند خالی باشد.";
                case PaymentOpResult.PinRequired:
                    return "کد پین درگاه نمیتواند خالی باشد.";
                case PaymentOpResult.CallbackRequired:
                    return "Callback نمیتواند خالی باشد.";
                case PaymentOpResult.AmountInvalid:
                    return "Amount باید عددی باشد.";
                case PaymentOpResult.AmountNegative:
                    return "Amount باید بزرگتر از 100 باشد.";
                case PaymentOpResult.PinEmptyOrInvalid:
                    return "کد پین درگاه اشتباه هست.";
                case PaymentOpResult.GatewyIpMismatched:
                    return "ایپی سرور با ایپی درگاه مطابقت ندارد.";
                case PaymentOpResult.TransactionIdRequired:
                    return "TransactionId نمیتواند خالی باشد.";
                case PaymentOpResult.TransactionIdInvalid:
                    return "تراکنش مورد نظر وجود ندارد.";
                case PaymentOpResult.PinTransactionIdMismatched:
                    return "کد پین درگاه با درگاه تراکنش مطابقت ندارد.";
                case PaymentOpResult.AmountMismatched:
                    return "مبلغ با مبلغ تراکنش مطابقت ندارد.";
                case PaymentOpResult.BankEmptyOrInvalid:
                    return "بانک وارد شده اشتباه میباشد.";
            }

            return "نامعلوم";
        }

        public static object ToHumanReadable(BankType bank) {
            switch (bank) {
                case BankType.Mellat:
                    return "ملت";
                case BankType.Saman:
                    return "سامان";
                case BankType.IranKish:
                    return "ایران کیش";
                case BankType.Pasargad:
                    return "پاسارگاد";
                case BankType.Parsian:
                    return "پارسیان";
            }

            return "نامعلوم";
        }

        public static string AsSuccess(string message) {
            return AsMessage(message, "success");
        }

        public static string AsError(string message) {
            return AsMessage(message, "danger");
        }

        private static string AsMessage(string message, string type) {
            return $"<div class=\"alert alert-{type}\">{message}</div>";
        }
    }
}