SEVERITY_COLORS = {
    'critical': '\033[91m',
    'high': '\033[93m',
    'medium': '\033[94m',
    'low': '\033[90m'
}
RESET = '\033[0m'


def print_findings(findings: list):
    if not findings:
        print("Ничего не найдено.")
        return

    print(f"\nНайдено совпадений: {len(findings)}\n")
    for f in findings:
        color = SEVERITY_COLORS.get(f['severity'], '')
        print(f"{color}[{f['severity'].upper()}]{RESET} {f['rule_name']}: {f['match']}")
        print(f"  Файл: {f['file']}:{f['line']}:{f['column']}")
        print(f"  Контекст: {f['context'][:120]}")
        print()

