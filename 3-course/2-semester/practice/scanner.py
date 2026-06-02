from pathlib import Path

def should_scan(filepath: Path) -> bool:
    if filepath.is_symlink() or not filepath.is_file():
        return False
    try:
        if filepath.stat().st_size > 100 * 1024 * 1024:
            return False
    except OSError:
        return False

    exclude_paths = ['.git', '__pycache__', 'node_modules', '.venv', 'venv', '.idea', '.vscode', 'vendor']
    for ex in exclude_paths:
        if ex in filepath.parts:
            return False

    binary_extensions = {'.exe', '.dll', '.so', '.bin', '.jpg', '.jpeg', '.png',
                         '.gif', '.bmp', '.ico', '.mp3', '.mp4', '.avi', '.mkv',
                         '.pdf', '.zip', '.tar', '.gz', '.7z', '.rar'}
    return filepath.suffix.lower() not in binary_extensions


def scan_file(filepath: Path, rules: list) -> list:
    findings = []
    try:
        with open(filepath, 'r', encoding='utf-8', errors='ignore') as f:
            for line_num, line in enumerate(f, 1):
                for rule in rules:
                    findings.extend(rule.check(line, line_num, filepath))
    except Exception:
        pass
    return findings


def scan_directory(root_path: str, rules: list) -> list:
    all_findings = []
    root = Path(root_path)

    for filepath in root.rglob('*'):
        if should_scan(filepath):
            all_findings.extend(scan_file(filepath, rules))

    return all_findings

