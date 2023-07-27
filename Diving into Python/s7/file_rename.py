from pathlib import Path


def rename_files(
        directory=Path.cwd() / 'files',
        new_name='new',
        num_digits=2,
        source_extension='txt',
        target_extension='csv',
        name_range=(3, 7)
):
    directory_path = Path(directory)

    for index, file_path in enumerate(directory_path.glob(f'*.{source_extension}')):
        original_name = file_path.stem[name_range[0] - 1:name_range[1]]

        new_file_name = f'{original_name}{new_name}{index:0{num_digits}d}.{target_extension}'
        new_file_path = file_path.with_name(new_file_name)
        file_path.rename(new_file_path)
