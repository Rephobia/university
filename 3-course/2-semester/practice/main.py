#!/usr/bin/env python3

import scanner
import cli
from passport_rule import PassportRule
from snils_rule import SNILSRule
from inn_rule import INNRule
from card_rule import CardRule
from email_rule import EmailRule
from phone_rule import PhoneRule

if __name__ == '__main__':
    import argparse
    parser = argparse.ArgumentParser(description='Поиск персональных данных в файлах')
    parser.add_argument('path', help='Путь к папке для сканирования')
    args = parser.parse_args()

    findings = scanner.scan_directory(args.path, [
        PassportRule(),
        SNILSRule(),
        INNRule(),
        CardRule(),
        EmailRule(),
        PhoneRule()
    ])

    cli.print_findings(findings)
